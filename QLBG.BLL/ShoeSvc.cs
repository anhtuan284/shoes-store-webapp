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
    public class ShoeSvc : GenericSvc<ShoeRep,Shoe>
    {
        ShoeRep shoeRep = new ShoeRep();

        public SingleRsp CreateShoe(ShoeReq shoeReq)
        {
            var res = new SingleRsp();
            Shoe shoe = new Shoe();
            shoe.Name = shoeReq.Name;
            shoe.CategoryId = shoeReq.CategoryId;
            res = shoeRep.CreateShoe(shoe);
            return res;
        }
    }
}
