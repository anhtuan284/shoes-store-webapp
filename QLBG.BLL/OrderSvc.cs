using QLBG.Common.BLL;
using QLBG.Common.Req;
using QLBG.Common.Rsp;
using QLBG.DAL;
using QLBG.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.BLL
{
    public class OrderSvc : GenericSvc <OrderRep,Order>
    {
        OrderRep orderRep = new OrderRep();
        public SingleRsp CreateOrder(OrderReq orderReq,int useid)
        {
            List<OrderDetail> listShoe = new List<OrderDetail>();
            var res = new SingleRsp();
            Order order = new Order();
            order.CreatedDate = DateTime.Now;
            order.Status = "Pending";
            order.CustomerId = useid;
            order.Total = orderReq.Price;
            foreach(var o in orderReq.Details)
            {
                listShoe.Add(new OrderDetail
                {
                    ShoeDetailId = o.Shoe_detail_id,
                    Amount= o.Amount,
                });
            }
            res = orderRep.CreateOrder(order, listShoe);
            return res;
        }

        public List<Order> GetOrders(int id)
        {
            return orderRep.GetOrders(id);
        }
        public SingleRsp Update(int orderid)
        {
            return orderRep.Update(orderid);
        }
        public SingleRsp AllOrder()
        {
            return orderRep.OrderAll();
        }
    }
}
