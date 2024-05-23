using QLBG.Common.DAL;
using QLBG.Common.Rsp;
using QLBG.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBG.DAL
{
    public class ShoeRep : GenericRep<manage_sale_shoesContext, Shoe> 
    { 
        public SingleRsp CreateShoe(Shoe shoe)
        {
            var res = new SingleRsp();
            using (manage_sale_shoesContext context = new manage_sale_shoesContext())
            {
                try
                {
                    var p = context.Shoes.Add(shoe);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    res = new SingleRsp();
                    res.SetError(ex.Message);
                }
            }
            return res;
        }
    }
}
