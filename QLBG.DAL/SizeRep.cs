using QLBG.Common.DAL;
using QLBG.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.DAL
{
    public class SizeRep : GenericRep<manage_sale_shoesContext, Size>
    {
        #region -- Overrides --

        public override Size Read(int id)
        {
            var m = base.All.First(x => x.Id == id);
            return m;
        }

        public int Remove(int id)
        {
            var m = base.All.First(i => i.Id == id);
            m = base.Delete(m);
            return m.Id;
        }

        #endregion

        #region -- Methods --


        #endregion
    }
}
