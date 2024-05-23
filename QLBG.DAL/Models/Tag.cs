using System;
using System.Collections.Generic;

#nullable disable

namespace QLBG.DAL.Models
{
    public partial class Tag
    {
        public Tag()
        {
            ShoeTags = new HashSet<ShoeTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ShoeTag> ShoeTags { get; set; }
    }
}
