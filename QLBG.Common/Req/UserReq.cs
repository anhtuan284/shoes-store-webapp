using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Common.Req
{
    public class UserReq
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public byte? Gender { get; set; }
        public string Address { get; set; }
    }
}
