using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/claims")]
    [Authorize]
    public class ClaimsController : ControllerBase
    {
        private readonly ClaimService _service;
        public ClaimsController(ClaimService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Claim>>> GetAll(
            [FromQuery] int? customerId,
            [FromQuery] int? policyId)
        {
            if (customerId.HasValue) return await _service.GetByCustomerIdAsync(customerId.Value);
            if (policyId.HasValue)   return await _service.GetByPolicyIdAsync(policyId.Value);
            return await _service.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Claim>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : result;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Claim claim)
        {
            var created = await _service.CreateAsync(claim);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id:int}")]
        [Authorize(Policy = "AgentOrAdmin")]
        public async Task<IActionResult> Update(int id, Claim claim)
        {
            var result = await _service.UpdateAsync(id, claim);
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
