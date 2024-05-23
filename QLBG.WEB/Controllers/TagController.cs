using Microsoft.AspNetCore.Mvc;
using QLBG.BLL;
using QLBG.Common.Req;

namespace QLBG.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : Controller
    {
        TagSvc tagSvc = new TagSvc();
        [HttpPost("create")]
        public IActionResult CreateTag([FromBody] TagReq tagReq)
        {
            var res = tagSvc.CreateTag(tagReq);
            return Created("cc",res);
        }
    }
}
