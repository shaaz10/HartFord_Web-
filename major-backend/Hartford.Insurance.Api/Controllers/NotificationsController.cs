using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationsController : ControllerBase
    {
        private readonly NotificationService _service;

        public NotificationsController(NotificationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Notification>>> GetAll([FromQuery] string? userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                return await _service.GetByUserIdAsync(userId);
            }
            return await _service.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Notification notification)
        {
            await _service.CreateAsync(notification);
            return Created($"api/notifications/{notification.Id}", notification);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(string id, Notification notification)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            notification.Id = id;
            await _service.UpdateAsync(id, notification);
            return NoContent();
        }
    }
}
