using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.Common.Rsp
{
    public class ProductRsp : SingleRsp
    {
        #region -- Methods --

        public ProductRsp() : base() { }

        #endregion

        #region -- Properties --

        /// <summary>
        /// Data
        /// </summary>
        public int Count {  get; set; }

        #endregion
    }
}
