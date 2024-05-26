using Microsoft.AspNetCore.Mvc;
using QLBG.WEB.Models;
using QLBG.WEB.Services;
using System.Net.WebSockets;

namespace QLBG.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VnPayController : Controller
    {
        private readonly IVnPaySvc _vnpSvc;
        public VnPayController(IVnPaySvc vnpSvc)
        {
            _vnpSvc = vnpSvc;
        }
        [HttpPost("create-pay-url")]
        public IActionResult Pay([FromBody] VnPayRequestModel req)
        {
            var payUrl = _vnpSvc.CreatePaymentUrl(HttpContext, req);

            return Ok(new { payUrl });
        }

        [HttpGet("payment-callback")]
        public IActionResult PaymentCallBack()
        {
            var responseModel = _vnpSvc.PaymentExcute(Request.Query);
            Console.WriteLine(responseModel);
            if (responseModel.Success)
            {
                return Ok(responseModel);
            }
            return BadRequest(responseModel);
        }
    }
}
