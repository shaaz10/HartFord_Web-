using Auth_demo.Data;
using Auth_demo.DTOs;
using Auth_demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auth_demo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

       
        [HttpPost("register")]
        public IActionResult Register(UserDto dto)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Email == dto.Email);

            if (existingUser != null)
            {
                return BadRequest("User already exists with this email.");
            }

           
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully.");
        }
        [HttpPost("login")]
       
        public IActionResult Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _context.Users
                .FirstOrDefault(u => u.Email == dto.Email
                                  && u.Password == dto.Password);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            if(users== null || users.Count == 0)
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }

    }
}