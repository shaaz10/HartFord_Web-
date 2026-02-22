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
        public PolicyApplicationsController(PolicyApplicationService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<PolicyApplication>>> GetAll(
            [FromQuery] int? agentId,
            [FromQuery] int? customerId)
        {
            if (agentId.HasValue)    return await _service.GetByAgentIdAsync(agentId.Value);
            if (customerId.HasValue) return await _service.GetByCustomerIdAsync(customerId.Value);
            return await _service.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PolicyApplication>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : result;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PolicyApplication app)
        {
            var created = await _service.CreateAsync(app);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Update(int id, PolicyApplication app)
        {
            var result = await _service.UpdateAsync(id, app);
            return result == null ? NotFound() : NoContent();
        }
    }
}
