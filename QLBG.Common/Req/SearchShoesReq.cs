using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Common.Req
{
    public class SearchShoesReq
    {
        public int? Page { get; set; }
        public int? Size { get; set; }
        public string? Keyword { get; set; }
        public int? CategoryId { get; set; }
    }

}

