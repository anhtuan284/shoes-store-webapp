using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Common.Req
{
    public class ShoeReq
    {
        public int? ShoeID { get; set; }
        public string? Name { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Price { get; set; }

        public IFormFile? Img { get; set; }
        public required List<SizeDetailReq> sizeDetail { get; set;}

    }
}
