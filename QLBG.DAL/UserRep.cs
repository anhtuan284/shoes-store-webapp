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
    public class UserRep : GenericRep<manage_sale_shoesContext,User>
    {
        public SingleRsp CreateUser(User user)
        {
            var res = new SingleRsp();
            using (manage_sale_shoesContext context = new manage_sale_shoesContext())
            {
                try
                {
                    var p = context.Users.Add(user);
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
        public User Login(String name)
        {
            try
            {
                return base.All.First(x => x.Username == name);
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
