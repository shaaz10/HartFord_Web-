using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/policies")]
    [Authorize]
    public class PoliciesController : ControllerBase
    {
        private readonly PolicyService _service;
        public PoliciesController(PolicyService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Policy>>> GetAll(
            [FromQuery] int? customerId,
            [FromQuery] int? agentId)
        {
            if (customerId.HasValue) return await _service.GetByCustomerIdAsync(customerId.Value);
            if (agentId.HasValue)   return await _service.GetByAgentIdAsync(agentId.Value);
            return await _service.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Policy>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : result;
        }

        [HttpPost]
        [Authorize(Policy = "AgentOrAdmin")]
        public async Task<IActionResult> Create(Policy policy)
        {
            var created = await _service.CreateAsync(policy);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id:int}")]
        [Authorize(Policy = "AgentOrAdmin")]
        public async Task<IActionResult> Update(int id, Policy policy)
        {
            var result = await _service.UpdateAsync(id, policy);
            return result == null ? NotFound() : NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
