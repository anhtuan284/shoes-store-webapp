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
        #region -- Overrides --

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            try
            {
                var m = _rep.Read(id);
                res.Data = m;
            }
            catch 
            {
                res.SetError("400", "Bad request");
            }
            return res;
        }


        public override SingleRsp Update(Size m)
        {
            var res = new SingleRsp();

            var m1 = m.Id > 0 ? _rep.Read(m.Id) : _rep.Read(m.Size1);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }
        #endregion

        #region -- Methods --

        public SizeSvc() { }


        #endregion
    }
}
