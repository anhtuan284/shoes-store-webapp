using System;
using System.Collections.Generic;

#nullable disable

namespace QLBG.DAL.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Total { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
