using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBG.BLL;
using QLBG.Common.Req;
using QLBG.Common.Rsp;
using QLBG.DAL;
using QLBG.DAL.Models;

namespace QLBG.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        [HttpPost("create")]
        public IActionResult createCategory([FromBody] SizeReq req)
        {
            var res = new SingleRsp();

            Size c = new Size();
            c.Size = req.Size;

            //res = SizeSvc.Create(c);
            return Created("cc", res);
        }
    }
}
