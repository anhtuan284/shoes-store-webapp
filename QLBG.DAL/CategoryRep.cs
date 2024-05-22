using QLBG.Common.DAL;
using QLBG.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBG.DAL
{
    public class CategoryRep : GenericRep<NorthwindContext, Category>
    {
        #region -- Overrides --

        //public override Category Read(int id)
        //{
        //    var res = All.FirstOrDefault(p => p.CategoryId == id);
        //    return res;
        //}
        public override Category Read(int id)
        {
            return base.Read(id);
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.CategoryId == id);
            m = base.Delete(m); 
            return m.CategoryId;
        }

        #endregion

        #region -- Methods --


        #endregion
    }
}
