using QLBG.Common.BLL;
using QLBG.Common.Rsp;
using QLBG.DAL;
using QLBG.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.BLL
{
    public class SizeSvc : GenericSvc<SizeRep, Size>
    {
       
        public SingleRsp AllSize()
        {
            var res = new SingleRsp();
            
            return res;
        }
    }
}
