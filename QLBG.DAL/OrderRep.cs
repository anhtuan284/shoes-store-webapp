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
using System.Transactions;

namespace QLBG.DAL
{
    public class OrderRep : GenericRep<manage_sale_shoesContext,Order>
    {
        public SingleRsp CreateOrder(Order order,List<OrderDetail> listShoe)
        {
            var res = new SingleRsp();
            using(manage_sale_shoesContext context = new manage_sale_shoesContext())
            {
                using(var trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Orders.Add(order);
                        context.SaveChanges();

                        foreach (var o in listShoe)
                        {
                            o.OrderId = order.Id;
                            context.OrderDetails.Add(o);
                        }
                        context.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        res.SetError(ex.Message);
                    }
                    
                    return res;
                }
            }
        }
        public List<Order> GetOrders(int id)
        {
            using (manage_sale_shoesContext ctx = new())
            {
                var query = ctx.Orders.AsQueryable().Where(x => x.CustomerId == id).Include(e => e.OrderDetails)
                                                                                        .ThenInclude(s => s.ShoeDetail)
                                                                                            .ThenInclude(s => s.Shoe)
                                                                                   .Include(o => o.OrderDetails)
                                                                                        .ThenInclude(od => od.ShoeDetail)
                                                                                            .ThenInclude(sd => sd.Size);
                return query.ToList();
            }
        }
        public SingleRsp OrderAll()
        {
            using(manage_sale_shoesContext ctx = new())
            {
                var res = new SingleRsp();
                var query = ctx.Orders.AsQueryable().Include(e => e.OrderDetails)
                                                        .ThenInclude(s => s.ShoeDetail)
                                                            .ThenInclude(s => s.Shoe)
                                                    .Include(o => o.OrderDetails)
                                                        .ThenInclude(od => od.ShoeDetail)
                                                            .ThenInclude(sd => sd.Size)
                                                    .Include(c => c.Customer);
                res.SetData("200",query.ToList());                               
                return res;
            }
        }
        public SingleRsp Update(int orderID)
        {
            using(manage_sale_shoesContext context = new())
            {
                var res = new SingleRsp();
                Order? order = context.Orders.FirstOrDefault(x => x.Id == orderID);
                if (order == null)
                {
                    res.SetError("Order not found");
                    return res;
                }
                try
                {
                    order.Status = "Accepted";
                    context.Update(order);
                    context.SaveChanges();
                }catch(Exception ex)
                {
                    res.SetError(ex.Message);
                }
                return res;
                
            }
        }
    }
}
