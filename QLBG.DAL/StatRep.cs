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
    public class StatRep:GenericRep <manage_sale_shoesContext,Order>
    {
        public SingleRsp RevenueByMonth()
        {
            SingleRsp SingleRsp = new SingleRsp();
            using(manage_sale_shoesContext ctx = new manage_sale_shoesContext())
            {
                var query = from o in ctx.Orders
                            group o by new { o.CreatedDate.Month } into g
                            select new 
                            {
                                OrderMonth = g.Key.Month,
                                TotalRevenue = g.Sum(x => x.Total)
                            };

                var revenues = query.OrderBy(r => r.OrderMonth).ToList();
                SingleRsp.SetData("200",revenues);
                return SingleRsp;
            }
        }
        public SingleRsp RevenueByShoe()
        {
            SingleRsp SingleRsp = new SingleRsp();
            using (manage_sale_shoesContext ctx = new manage_sale_shoesContext())
            {
                var query = ctx.Shoes.AsQueryable().Join(ctx.ShoeDetails,
                                                            shoe => shoe.Id,
                                                            shoeDetails => shoeDetails.ShoeId,
                                                            (shoe, shoeDetails) => new { Shoe = shoe, ShoeDetails = shoeDetails })
                                                       .Join(ctx.OrderDetails,
                                                             joined => joined.ShoeDetails.Id,
                                                             orderDetail => orderDetail.ShoeDetailId,
                                                             (joined, orderDetail) => new { joined.ShoeDetails, joined.Shoe, OrderDetail = orderDetail })
                                                       .GroupBy(x => x.Shoe.Name)
                                                       .Select(g => new
                                                       {
                                                           ShoeName = g.Key,
                                                           Total = g.Count()
                                                       })
                                                       .OrderByDescending(x => x.Total)
                                                       .Take(5)
                                                       .ToList();
                SingleRsp.SetData("200",query);
                return SingleRsp;
            }
        }
    }
}
