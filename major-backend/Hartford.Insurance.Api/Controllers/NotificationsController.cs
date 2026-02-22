using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly NotificationService _service;
        public NotificationsController(NotificationService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Notification>>> GetAll([FromQuery] int? userId)
        {
            if (userId.HasValue) return await _service.GetByUserIdAsync(userId.Value);
            return await _service.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Notification>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : result;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Notification notification)
        {
            var created = await _service.CreateAsync(notification);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Update(int id, Notification notification)
        {
            var result = await _service.UpdateAsync(id, notification);
            return result == null ? NotFound() : NoContent();
        }
    }
}
