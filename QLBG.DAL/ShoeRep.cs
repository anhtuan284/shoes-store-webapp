using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using QLBG.Common.DAL;
using QLBG.Common.Req;
using QLBG.Common.Rsp;
using QLBG.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QLBG.DAL
{
    public class ShoeRep : GenericRep<manage_sale_shoesContext, Shoe>
    {
        public SingleRsp Readinfo(int id)
        {
            using (var ctx = new manage_sale_shoesContext())
            {
                var m = base.All.AsQueryable().Where(x => x.Id == id).Include(x => x.ShoeDetails)
                .ThenInclude(d => d.Size).First();
                var res = new SingleRsp();
                res.Data = m;
                return res;
            }
        }

        //Add new Shoes with CategoryId
        public SingleRsp CreateShoe(ShoeReq shoeReq,Uri url)
        {
            using (var ctx = new manage_sale_shoesContext())
            using (var trans = ctx.Database.BeginTransaction())
            {
                var res = new SingleRsp();
                try
                {
                    if (shoeReq.Name == null || shoeReq.CategoryId == null)
                    {
                        throw new Exception("Missing input field");
                    }
                    var newShoe = new Shoe { Name = shoeReq.Name, CategoryId = (int)shoeReq.CategoryId,Price = shoeReq.Price, Image = url.ToString() };
                    ctx.Shoes.Add(newShoe);
                    ctx.SaveChanges();

                    var shoeDetails = shoeReq.sizeDetail.Select(detail => new ShoeDetail
                    {
                        ShoeId = newShoe.Id,
                        SizeId = detail.SizeId,
                        Quantity = detail.Quantity,
                    });

                    ctx.ShoeDetails.AddRange(shoeDetails);
                    ctx.SaveChanges();
                    res.Data = newShoe;
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    res.SetError(ex.Message);
                    trans.Rollback();
                }
                return res;
            }
        }


        private void UpdatePropertyIfNotNull<T>(T value, Action updateAction)
        {
            if (value != null)
                updateAction();
        }

        // Add Sizes to Shoe
        public SingleRsp Edit(ShoeReq shoeReq)
        {
            var res = new SingleRsp();
            using (var context = new manage_sale_shoesContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var currentShoe = context.Shoes.FirstOrDefault(s => s.Id == shoeReq.ShoeID);
                    if (currentShoe == null)
                    {
                        res.SetError("Shoe not found.");
                        return res;
                    }
                    UpdatePropertyIfNotNull(shoeReq.Name, () => currentShoe.Name = shoeReq.Name);
                    UpdatePropertyIfNotNull(shoeReq.CategoryId, () => currentShoe.CategoryId = (int)shoeReq.CategoryId);

                    if (shoeReq.sizeDetail != null && shoeReq.sizeDetail.Any())
                    {
                        foreach (var detail in shoeReq.sizeDetail)
                        {
                            var existingShoeDetail = context.ShoeDetails
                                .FirstOrDefault(sd => sd.ShoeId == currentShoe.Id && sd.SizeId == detail.SizeId);

                            if (existingShoeDetail != null)
                            {
                                existingShoeDetail.Quantity = detail.Quantity;
                            }
                            else
                            {
                                var newShoeDetail = new ShoeDetail
                                {
                                    ShoeId = currentShoe.Id,
                                    SizeId = detail.SizeId,
                                    Quantity = detail.Quantity
                                };
                                context.ShoeDetails.Add(newShoeDetail);
                            }
                        }
                    }
                    context.SaveChanges();
                    res.SetMessage("Change shoes info successfully !");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    res.SetError(ex.Message);
                }
            }
            return res;
        }

        // Search
        public ProductRsp SearchShoes(SearchShoesReq req)
        {
            var res = new ProductRsp();
            using (manage_sale_shoesContext ctx = new())
            {
                var query = ctx.Shoes.AsQueryable();

                if (!string.IsNullOrEmpty(req.Keyword))
                    query = query.Where(x => x.Name.Contains(req.Keyword));

                if (req.CategoryId.HasValue)
                    query = query.Where(x => x.CategoryId == req.CategoryId.Value);

                res.Count = query.Count();

                // Pagination
                if (req.Page.HasValue && req.Size.HasValue)
                {
                    int skip = (req.Page.Value - 1) * req.Size.Value;
                    query = query.Skip(skip).Take(req.Size.Value);
                }

                res.Data = query.ToList();
            }
            return res;
        }

    }
}
