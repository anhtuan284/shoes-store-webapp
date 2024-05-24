using QLBG.Common.DAL;
using QLBG.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.DAL
{
    public class CategoryRep : GenericRep<manage_sale_shoesContext, Category>
    {
        #region -- Overrides --
        
        public override Category Read(int id)
        {
            var m = base.All.First(x => x.Id == id);
            return m;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.Id == id);
            m = base.Delete(m);
            base.Context.SaveChanges();
            return m.Id;
        }

        #endregion

        #region -- Methods --


        #endregion
    }
}
