using Microsoft.EntityFrameworkCore;
using QLBG.Common.DAL;
using QLBG.Common.Rsp;
using QLBG.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.DAL
{
    public class CommentRep : GenericRep<manage_sale_shoesContext,Comment>
    {
        public SingleRsp AddComment(Comment comment)
        {
            var res = new SingleRsp();
            using(manage_sale_shoesContext ctx = new())
            {
                try
                {
                    ctx.Add(comment);
                    ctx.SaveChanges();
                }catch(Exception ex)
                {
                    res.SetError(ex.Message);
                }
                return res;
            }
        }

        public SingleRsp GetComment(int id) 
        {
            var res = new SingleRsp();
            using (manage_sale_shoesContext ctx = new())
            {
                var query = ctx.Comments.AsQueryable().Join(ctx.OrderDetails,
                                                            comment => comment.Id,
                                                            orderDetail => orderDetail.Id,
                                                            (comment, orderDetail) => new { Comment = comment, OrderDetail = orderDetail })
                                                       .Join(ctx.ShoeDetails,
                                                             joined => joined.OrderDetail.ShoeDetailId,
                                                             shoeDetail => shoeDetail.Id,
                                                             (joined,shoeDetail) => new {joined.OrderDetail,joined.Comment,ShoeDetail = shoeDetail})
                                                       .Join(ctx.Orders,
                                                             joined =>joined.OrderDetail.OrderId,
                                                             order => order.Id,
                                                             (joined,order) => new { joined.OrderDetail, joined.Comment, joined.ShoeDetail, Order = order})
                                                       .Join(ctx.Customers,
                                                             joined => joined.Order.CustomerId,
                                                             customer => customer.Id,
                                                             (joined, customer) => new { joined.OrderDetail, joined.Comment, joined.ShoeDetail, joined.Order,Customer = customer })
                                                       .Where(x=> x.ShoeDetail.ShoeId == id)
                                                       .Select(x => new { x.Comment, x.Customer.Name })
                                                       .ToList();
                res.SetData("200",query);
                return res;
            }
        }

    }
}
