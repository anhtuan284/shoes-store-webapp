using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLBG.BLL;
using QLBG.Common.Req;
using QLBG.Common.Rsp;
using QLBG.DAL;
using QLBG.DAL.Models;
using System.Security.Claims;

namespace QLBG.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        UserSvc userSvc = new UserSvc();
        OrderSvc orderSvc = new OrderSvc();

        public OrderController()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }
        [HttpPost("create"), Authorize]
        public IActionResult CreateOrder([FromBody] OrderReq orderReq)
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext is not null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            User user = userSvc.GetUserByName(result);
            SingleRsp? res = orderSvc.CreateOrder(orderReq, user.Id);
            return res.Success?Ok(res):BadRequest(res);
        }
        [HttpGet("get"), Authorize]
        public IActionResult Get()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext is not null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            User user = userSvc.GetUserByName(result);
            SingleRsp res = new SingleRsp();
            res.SetData("200",orderSvc.GetOrders(user.Id));
            return Ok(res);
        }

        [HttpPut("{id}"), Authorize(Roles = "admin")]
        public IActionResult Update([FromRoute] int id)
        {
            var res = new SingleRsp();
            res = orderSvc.Update(id);
            return res.Success ? Ok(res) : BadRequest(res);
        }

        [HttpGet("all"), Authorize(Roles = "admin")]
        public IActionResult All()
        {
            var res = new SingleRsp();
            res = orderSvc.AllOrder();
            return res.Success ? Ok(res) : BadRequest(res);
        }
    }
}
