using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtGenerator.Models;

namespace JwtGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JWTSettings _jwtSettings;

        public AuthController(IOptions<JWTSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("generate")]
        public IActionResult GenerateToken()
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Shaaz"),
                new Claim(ClaimTypes.Email, "shaaz@gmail.com"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim("CustomClaim", "Hartford")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new
            {
                token = tokenString
            });
        }
    }
}
