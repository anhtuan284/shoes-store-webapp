using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QLBG.BLL;
using QLBG.Common.Req;
using QLBG.DAL.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QLBG.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        { 
            this._configuration = configuration;
        }

        UserSvc userSvc = new UserSvc();
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserReq userReq)
        {
            var res = userSvc.CreateUser(userReq);
            return Ok(res);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginReq loginReq)
        {
            User user = userSvc.Login(loginReq);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:token").Value!));

            var cred = new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
