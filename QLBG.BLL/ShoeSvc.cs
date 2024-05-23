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
            var res = shoeRep.CreateShoe(shoeReq);
            return res;
        }

        public SingleRsp AddSize(ShoeReq shoeReq)
        {
            var res = shoeRep.AddSize(shoeReq);
            return res;
        }

        public SingleRsp SearchShoes(SearchShoesReq req)
        {
            SingleRsp res = new ();
            res.Data = _rep.SearchShoes(req);

            return res;
        }
    }
}
