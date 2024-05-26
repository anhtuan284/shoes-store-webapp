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
    public class StatSvc:GenericSvc<StatRep,Order>
    {
        StatRep statRep = new StatRep();
        public SingleRsp RevenueByMonth()
        {
            return statRep.RevenueByMonth();
        }
        public SingleRsp RevenueByShoe() 
        {
            return statRep.RevenueByShoe();
        }
    }
}
