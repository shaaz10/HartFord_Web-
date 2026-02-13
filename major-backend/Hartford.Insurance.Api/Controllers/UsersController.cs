using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;

        public UsersController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("by-email")]
        public async Task<ActionResult<User>> GetByEmail([FromQuery] string email)
        {
            var user = await _service.GetByEmailAsync(email);
            if (user == null) return NotFound();
            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _service.CreateAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(string id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null) return NotFound();
            return user;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(string id, User user)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            user.Id = id; // Ensure ID matches URL
            await _service.UpdateAsync(id, user);
            return NoContent();
        }
    }
}
