using System;
using System.Collections.Generic;

#nullable disable

namespace QLBG.DAL.Models
{
    public partial class ShoeTag
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public int TagId { get; set; }

        public virtual Shoe Shoe { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
