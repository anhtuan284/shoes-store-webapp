using QLBG.Common.BLL;
using QLBG.Common.Req;
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
                    
            }catch (Exception)
            {
                res.SetError("400", "Bad request");
            }

            return res;
        }


        public SingleRsp Update(int id, CategoryReq req)
        {
            var res = new SingleRsp();
            var cat = _rep.Read(id);

            cat.Name = req.Name;
            cat.Description = req.Description;

            if (cat == null)
            {
                res.SetError("Error!", "No category.");
            }
            else
            {
                res = base.Update(cat);
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
