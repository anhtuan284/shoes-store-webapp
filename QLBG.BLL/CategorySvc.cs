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
    public class CategorySvc : GenericSvc<CategoryRep, Category>
    {
        #region -- Overrides --


        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            try
            {
                var m = _rep.Read(id);
                res.Data = m;
                    
            }catch (Exception ex)
            {
                res.SetError("400", "Bad request");
            }

            return res;
        }


        public override SingleRsp Update(Category m)
        {
            var res = new SingleRsp();

            var m1 = m.Id > 0 ? _rep.Read(m.Id) : _rep.Read(m.Description);
            if (m1 == null)
            {
                res.SetError("EZ103", "No category.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }

        public override SingleRsp Delete(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Remove(id);
            return res;
        }
        #endregion

        #region -- Methods --

        public CategorySvc() { }


        #endregion
    }
}
