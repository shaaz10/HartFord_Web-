using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/policies")]
    public class PoliciesController : ControllerBase
    {
        private readonly PolicyService _service;

        public PoliciesController(PolicyService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<List<Policy>>> GetAll([FromQuery] string? customerId, [FromQuery] string? agentId)
        {
            if (!string.IsNullOrEmpty(customerId))
            {
                return await _service.GetByCustomerIdAsync(customerId);
            }
            if (!string.IsNullOrEmpty(agentId))
            {
                return await _service.GetByAgentIdAsync(agentId);
            }
            return await _service.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Policy policy)
        {
            await _service.CreateAsync(policy);
            return CreatedAtAction(nameof(GetById), new { id = policy.Id }, policy);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(string id, Policy policy)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            policy.Id = id;
            await _service.UpdateAsync(id, policy);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
