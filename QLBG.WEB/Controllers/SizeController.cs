using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBG.BLL;
using QLBG.Common.Req;
using QLBG.Common.Rsp;
using QLBG.DAL;
using QLBG.DAL.Models;

namespace QLBG.WEB.Controllers
{
    [Route("api/[controller]"), Authorize(Roles = "admin")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        SizeSvc sizeSvc = new SizeSvc();
        [HttpPost("create")]
        public IActionResult createCategory([FromBody] SizeReq req)
        {
            var res = new SingleRsp();

            Size c = new Size();
            c.Size1 = req.Size;

            res = sizeSvc.Create(c);
            return Created("200", res);
        }
        [HttpGet("all")]
        public IActionResult AllSize()
        {
            var res = new SingleRsp();
            res.Data = sizeSvc.All;

            return Ok(res);

        }
    }
}
