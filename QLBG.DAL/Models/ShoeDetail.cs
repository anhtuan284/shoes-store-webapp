using System;
using System.Collections.Generic;

#nullable disable

namespace QLBG.DAL.Models
{
    public partial class ShoeDetail
    {
        public ShoeDetail()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int ShoeId { get; set; }
        public int SizeId { get; set; }
        public int Quantity { get; set; }

        public virtual Shoe Shoe { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
