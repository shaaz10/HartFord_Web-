using Hartford.Insurance.Api.Data;
using Hartford.Insurance.Api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SecurityClaim = System.Security.Claims.Claim;

namespace Hartford.Insurance.Api.Services
{
    public class AuthService
    {
        private readonly UserService _userService;
        private readonly IConfiguration _config;

        public AuthService(UserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        public async Task<AuthResponse?> LoginAsync(LoginRequest request)
        {
            var user = await _userService.GetByEmailAsync(request.Email);
            if (user == null) return null;

            bool isValid;
            try
            {
                isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            }
            catch
            {
                return null;
            }
            if (!isValid) return null;

            return BuildAuthResponse(user);
        }

        public async Task<AuthResponse?> RegisterAsync(RegisterRequest request)
        {
            var existing = await _userService.GetByEmailAsync(request.Email);
            if (existing != null) return null;

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = request.Role.ToLower()
            };

            await _userService.CreateAsync(user);
            return BuildAuthResponse(user);
        }

        private AuthResponse BuildAuthResponse(User user)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"]!;
            var issuer = jwtSettings["Issuer"]!;
            var audience = jwtSettings["Audience"]!;
            var expiryHours = int.Parse(jwtSettings["ExpiryInHours"] ?? "24");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new SecurityClaim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new SecurityClaim(JwtRegisteredClaimNames.Email, user.Email),
                new SecurityClaim(ClaimTypes.Role, user.Role),
                new SecurityClaim("name", user.Name),
                new SecurityClaim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var expiry = DateTime.UtcNow.AddHours(expiryHours);
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expiry,
                signingCredentials: credentials
            );

            return new AuthResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Id = user.Id.ToString(),
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                ExpiresAt = expiry
            };
        }
    }
}
