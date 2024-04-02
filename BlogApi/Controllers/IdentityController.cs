using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class IdentityController : ControllerBase
    {
        private const string TokenSecret = "thisshouldnotbestoredherebutitwilldountiliactuallyknowwhattheheckimdoing";
        private static readonly TimeSpan TokenLifeTime = TimeSpan.FromMinutes(30);

        private readonly string TokenIssuer;
        private readonly string TokenAudience;

        public IdentityController(IConfiguration configuration)
        {
            TokenIssuer = configuration["JwtSettings:Issuer"];
            TokenAudience = configuration["JwtSettings:Audience"];
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = Guid.NewGuid(); 
            var email = model.Email;    
            var password = model.Password;

            // Generate JWT token
            var token = GenerateJwtToken(userId, email, password);

            return Ok(new { token });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok("Login Succeded");
        }

        private string GenerateJwtToken(Guid userId, string email, string password)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(TokenSecret);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim("password", password),
                new Claim("userid", userId.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(TokenLifeTime),
                Audience = TokenAudience, 
                Issuer = TokenIssuer,     
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
