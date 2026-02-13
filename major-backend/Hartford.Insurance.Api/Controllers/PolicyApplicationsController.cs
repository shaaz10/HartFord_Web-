using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/policyApplications")]
    public class PolicyApplicationsController : ControllerBase
    {
        private readonly PolicyApplicationService _service;

        public PolicyApplicationsController(PolicyApplicationService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PolicyApplication>> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<List<PolicyApplication>>> GetAll([FromQuery] string? agentId)
        {
            if (!string.IsNullOrEmpty(agentId))
            {
                return await _service.GetByAgentIdAsync(agentId);
            }
            return await _service.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PolicyApplication app)
        {
            await _service.CreateAsync(app);
            return CreatedAtAction(nameof(GetById), new { id = app.Id }, app);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(string id, PolicyApplication app)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            app.Id = id;
            await _service.UpdateAsync(id, app);
            return NoContent();
        }
    }
}
