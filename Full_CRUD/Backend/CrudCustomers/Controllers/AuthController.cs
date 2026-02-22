using CrudCustomers.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CrudCustomers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            var (success, error) = await _auth.RegisterAsync(req.Email, req.Password, req.Role);
            if (!success) return BadRequest(new { error });
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var (success, token, error) = await _auth.LoginAsync(req.Email, req.Password);
            if (!success) return Unauthorized(new { error });
            return Ok(new { token });
        }

        public record RegisterRequest(string Email, string Password, string Role);
        public record LoginRequest(string Email, string Password);
    }
}
