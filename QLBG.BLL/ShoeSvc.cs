using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
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
    public class ShoeSvc : GenericSvc<ShoeRep, Shoe>
    {
        ShoeRep shoeRep = new ShoeRep();
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            try
            {
                var m = _rep.Read(id);
                res.Data = m;

            }
            catch (Exception)
            {
                res.SetError("400", "Bad request");
            }

            return res;
        }

        public SingleRsp CreateShoe(ShoeReq shoeReq,Uri url)
        {
            var res = shoeRep.CreateShoe(shoeReq, url);
            return res;
        }

        public SingleRsp Edit(ShoeReq shoeReq)
        {
            var res = shoeRep.Edit(shoeReq);
            return res;
        }

        public SingleRsp SearchShoes(SearchShoesReq req)
        {
            var res = _rep.SearchShoes(req);
            return res;
        }
    }
}
