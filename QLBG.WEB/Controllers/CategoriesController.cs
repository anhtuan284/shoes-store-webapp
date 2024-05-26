using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
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

        // api/Categories/create
        [HttpPost("create"), Authorize(Roles = "admin")]
        public IActionResult createCategory([FromBody] CategoryReq req)
        {
            Category c = new()
            {
                Name = req.Name,
                Description = req.Description
            };

            var res = categorySvc.Create(c);

            return Created(new Uri(Request.GetEncodedUrl()),res);
        }

        // api/Categories/{id}
        [HttpGet("{id}")]
        public IActionResult getCategoryById([FromRoute] int id)
        {
            var res = categorySvc.Read(id);
            return Ok(res);
        }

        // api/Categories/{id}
        [HttpDelete("{id}"), Authorize(Roles = "admin")]
        public IActionResult deleteCategory([FromRoute] int id)
        {
            var res = categorySvc.Delete(id);
            return Ok(res);
        }

        // api/Categories/all
        [HttpGet("all")]
        public IActionResult getAllCategories()
        {
            var res = new SingleRsp();
            res.Data = categorySvc.All;

            return Ok(res);
        }
    }
}
