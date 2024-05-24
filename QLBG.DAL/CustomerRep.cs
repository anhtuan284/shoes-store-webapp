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
    public class CustomerRep : GenericRep<manage_sale_shoesContext, Customer>
    {
        public SingleRsp CreateCustomer(Customer c)
        {
            var res = new SingleRsp();
            using (manage_sale_shoesContext context = new manage_sale_shoesContext())
            {
                try
                {
                    var p = context.Customers.Add(c);
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
        public override Customer Read(int id)
        {
            var m = base.All.First(x => x.Id == id);
            return m;
        }
    }
}
