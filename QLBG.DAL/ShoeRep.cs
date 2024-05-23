using Microsoft.EntityFrameworkCore;
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
        //Add new Shoes with CategoryId
        public SingleRsp CreateShoe(ShoeReq shoeReq)
        {
            var res = new SingleRsp();
            using (manage_sale_shoesContext context = new manage_sale_shoesContext())
            {
                try
                {
                    var newShoe = new Shoe { Name = shoeReq.Name, CategoryId = shoeReq.CategoryId };
                    context.Shoes.Add(newShoe);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    res = new SingleRsp();
                    res.SetError(ex.Message);
                }
                return res;
            }
        }

        // Add Sizes to Shoe
        public SingleRsp AddSize(ShoeReq shoeReq)
        {
            var res = new SingleRsp();
            using (manage_sale_shoesContext context = new manage_sale_shoesContext())
            {
                try
                {
                    var newShoe = new Shoe { Name = shoeReq.Name, CategoryId = shoeReq.CategoryId };
                    context.Shoes.Add(newShoe);
                    context.SaveChanges();
                    var shoeDetails = shoeReq.SizeId.Select(sizeId => new ShoeDetail
                    {
                        ShoeId = newShoe.Id,
                        SizeId = sizeId,
                        Quantity = 1
                    });

                    context.ShoeDetails.AddRange(shoeDetails);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    res = new SingleRsp();
                    res.SetError(ex.Message);
                }
            }
            return res;
        }

        // Search
        public List<Shoe> SearchShoes(SearchShoesReq req)
        {
            using (manage_sale_shoesContext ctx = new())
            {
                var query = ctx.Shoes.AsQueryable();

                if (!string.IsNullOrEmpty(req.Keyword))
                {
                    query = query.Where(x => x.Name.Contains(req.Keyword));
                }

                if (req.CategoryId.HasValue)
                {
                    query = query.Where(x => x.CategoryId == req.CategoryId.Value);
                }

                // Pagination
                if (req.Page.HasValue && req.Size.HasValue)
                {
                    int skip = (req.Page.Value - 1) * req.Size.Value;
                    query = query.Skip(skip).Take(req.Size.Value);
                }

                return query.ToList();

            }
        }

    }
}
