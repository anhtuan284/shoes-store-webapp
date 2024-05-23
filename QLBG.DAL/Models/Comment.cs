using System;
using System.Collections.Generic;

#nullable disable

namespace QLBG.DAL.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string Comment1 { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
    }
}
