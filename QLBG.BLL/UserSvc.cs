using BCrypt.Net;
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
    public class UserSvc : GenericSvc<UserRep,User>
    {
        UserRep userRep = new UserRep();

        public SingleRsp CreateUser(UserReq userReq)
        {
            var res = new SingleRsp();
            User user = new User();
            user.Username = userReq.Username;
            user.Password = BCrypt.Net.BCrypt.HashPassword(userReq.Password);
            user.Role = "customer";
            res = userRep.CreateUser(user);
            return res;
        }
        public User Login(LoginReq login)
        {
            User user = userRep.Login(login.Username);
            if(user != null)
            {
                if(BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
