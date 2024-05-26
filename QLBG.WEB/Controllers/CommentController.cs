using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLBG.BLL;
using QLBG.Common.Req;
using QLBG.Common.Rsp;
using QLBG.DAL.Models;
using System.Security.Claims;

namespace QLBG.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        readonly CommentSvc commentSvc = new CommentSvc();
        readonly UserSvc userSvc = new UserSvc();
        public CommentController()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }

        [HttpPost("Add/{id}"), Authorize]
        public IActionResult AddComment([FromBody] CommentReq commentReq, [FromRoute] int id)
        {
            var res = commentSvc.AddComment(commentReq, id);
            return res.Success ? Ok(res) : BadRequest(res);
        }
        [HttpGet("shoe/{id}")]
        public IActionResult GetComment(int id)
        {
            var res = commentSvc.GetComment(id);
            return Ok(res);
        }
    }
}
