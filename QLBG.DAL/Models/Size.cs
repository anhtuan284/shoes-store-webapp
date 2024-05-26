using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        public int Size1 { get; set; }
        [JsonIgnore]
        public virtual ICollection<ShoeDetail> ShoeDetails { get; set; }
    }
}
