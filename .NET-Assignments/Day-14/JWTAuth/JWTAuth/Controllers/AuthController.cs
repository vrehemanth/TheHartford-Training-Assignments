using AuthApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController :ControllerBase
    {
        private readonly JwtSettings _jwtsettings;

        public AuthController(IOptions<JwtSettings> jwtsettings)
        {
            _jwtsettings = jwtsettings.Value;
        }
        [HttpPost("token")]

        public IActionResult GenerateToken()
        {

            var claims = new[]

            {
                new Claim(JwtRegisteredClaimNames.Sub, "testuser"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            //Console.WriteLine("SecretKey in Controller: " + _jwtsettings.SecretKey);

            if (string.IsNullOrWhiteSpace(_jwtsettings.SecretKey))
                return StatusCode(500, "JWT SecretKey is not configured.");
    

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtsettings.SecretKey!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

              issuer: _jwtsettings.Issuer,

              audience: _jwtsettings.Audience,

              claims: claims,

              expires: DateTime.Now.AddMinutes(_jwtsettings.ExpiryMinutes),

              signingCredentials: creds

              );

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));

        }
    }
}