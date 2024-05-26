using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Common.Req
{
    public class OrderReq
    {
        public int CustomerID { get; set; }
        public int Price { get; set; }
        public required List<OrderDetailReq> Details { get; set; }
    }
}
