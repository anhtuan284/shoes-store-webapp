using System;
using System.Collections.Generic;

#nullable disable

namespace QLBG.DAL.Models
{
    public partial class Size
    {
        public Size()
        {
            ShoeDetails = new HashSet<ShoeDetail>();
        }

        public int Id { get; set; }
        public int Size { get; set; }

        public virtual ICollection<ShoeDetail> ShoeDetails { get; set; }
    }
}
