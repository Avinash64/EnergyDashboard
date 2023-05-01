using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EnergyDashboardAPI.Model;
namespace EnergyDashboardAPI.Controllers {
    [Route("api/login")]
    [ApiController]
    public class AuthenticationController: ControllerBase {

               [HttpGet]
        public string Get()
        {
            return "yeet";
        }

        [HttpPost]
        public IActionResult Login([FromBody] Login user) {
            if (user is null) {
                return BadRequest("Invalid user request!!!");
            }
            if (user.UserName == "username" && user.Password == "password") {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"], audience: ConfigurationManager.AppSetting["JWT:ValidAudience"], claims: new List < Claim > (), expires: DateTime.Now.AddMinutes(6), signingCredentials: signinCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new JWTTokenResponse {
                    Token = tokenString
                });
            }
            return Unauthorized();
        }
    }
}