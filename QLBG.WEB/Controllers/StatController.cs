using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLBG.BLL;

namespace QLBG.WEB.Controllers
{
    [Route("api/[controller]"), Authorize(Roles = "admin")]
    [ApiController]
    public class StatController : Controller
    {
        StatSvc statSvc = new StatSvc();
        [HttpGet("ByMonth")]
        public IActionResult RevenueByMonth()
        {
            return Ok(statSvc.RevenueByMonth());
        }
        [HttpGet("ByShoe")]
        public IActionResult RevenueByShoe()
        {
            return Ok(statSvc.RevenueByShoe());
        }
    }
}
