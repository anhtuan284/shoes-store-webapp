using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual Shoe Shoe { get; set; }
        [JsonIgnore]
        public virtual Size Size { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
