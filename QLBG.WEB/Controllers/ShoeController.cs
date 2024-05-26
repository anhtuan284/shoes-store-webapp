using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using QLBG.BLL;
using QLBG.Common.Req;
using QLBG.Common.Rsp;
using QLBG.DAL;
using System.Data;

namespace QLBG.WEB.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ShoeController : Controller
    {
        private readonly Cloudinary _cloudinary;

        public ShoeController(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }
        ShoeSvc shoeSvc = new ShoeSvc();

        [HttpPost("create"), Authorize(Roles = "admin")]
        [Consumes("multipart/form-data")]
        public IActionResult CreateShoe([FromForm] ShoeReq shoeReq)
        {
            var res = new SingleRsp();
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(shoeReq.Img.FileName, shoeReq.Img.OpenReadStream()),

            };
            var uploadResult = _cloudinary.Upload(uploadParams);

            if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                res = shoeSvc.CreateShoe(shoeReq, uploadResult.Url);
                return Created(new Uri(Request.GetEncodedUrl()), res);
            }
            res.SetMessage("Image not found");
            return BadRequest(res);
        }

        [HttpGet("{id}")]
        public IActionResult ViewSingleShoe([FromRoute] int id)
        {
            var res = shoeSvc.Read(id);
            return Ok(res);
        }

        [HttpPut("edit"), Authorize(Roles = "admin")]
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
