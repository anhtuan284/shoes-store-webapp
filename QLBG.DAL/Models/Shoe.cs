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
            ShoeTags = new HashSet<ShoeTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ShoeDetail> ShoeDetails { get; set; }
        public virtual ICollection<ShoeTag> ShoeTags { get; set; }
    }
}
