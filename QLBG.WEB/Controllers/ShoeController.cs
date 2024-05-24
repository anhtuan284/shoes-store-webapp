using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using QLBG.BLL;
using QLBG.Common.Req;

namespace QLBG.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeController : Controller
    {
        ShoeSvc shoeSvc = new();
        [HttpPost("create")]
        public IActionResult CreateTag([FromBody] ShoeReq shoeReq)
        {
            var res = shoeSvc.CreateShoe(shoeReq);
            return Created(new Uri(Request.GetEncodedUrl()), res);
        }

        [HttpGet("{id}")]
        public IActionResult ViewSingleShoe([FromRoute] int id)
        {
            var res = shoeSvc.Read(id);
            return Ok(res);
        }

        [HttpPut("edit")]
        public IActionResult Edit([FromBody] ShoeReq shoeReq)
        {
            var res = shoeSvc.Edit(shoeReq);
            return Created(new Uri(Request.GetEncodedUrl()), res);
        }

        [HttpGet]
        public IActionResult Search([FromQuery] SearchShoesReq req)
        {
            var res = shoeSvc.SearchShoes(req);
            return Ok(res);
        }
    }
}
