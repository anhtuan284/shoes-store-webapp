using System;
using System.Collections.Generic;

#nullable disable

namespace QLBG.DAL.Models
{
    public partial class Shoe
    {
        public Shoe()
        {
            ShoeDetails = new HashSet<ShoeDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ShoeDetail> ShoeDetails { get; set; }
    }
}
