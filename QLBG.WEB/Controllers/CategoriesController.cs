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
    public class CategoriesController : ControllerBase
    {
        private readonly CategorySvc categorySvc;
        public CategoriesController()
        {
            categorySvc = new CategorySvc();
        }

        [HttpPost("create")]
        public IActionResult createCategory([FromBody] CategoryReq req)
        {
            var res = new SingleRsp();

            Category c = new Category();
            c.Name = req.Name;
            c.Description = req.Description;

            res = categorySvc.Create(c);
            return Created("cc",res);
        }

        [HttpPost("get-by-id")]
        public IActionResult getCategoryById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = categorySvc.Read(req.Id);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public IActionResult getAllCategories()
        {
            var res = new SingleRsp();
            res.Data = categorySvc.All;
            return Ok(res);
        }
    }
}
