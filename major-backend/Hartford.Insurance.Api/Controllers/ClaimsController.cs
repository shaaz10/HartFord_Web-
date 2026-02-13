using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/claims")]
    public class ClaimsController : ControllerBase
    {
        private readonly ClaimService _service;

        public ClaimsController(ClaimService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Claim>> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<List<Claim>>> GetAll([FromQuery] string? customerId, [FromQuery] string? policyId)
        {
            if (!string.IsNullOrEmpty(customerId))
            {
                return await _service.GetByCustomerIdAsync(customerId);
            }
            if (!string.IsNullOrEmpty(policyId))
            {
                return await _service.GetByPolicyIdAsync(policyId);
            }
            return await _service.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Claim claim)
        {
            await _service.CreateAsync(claim);
            return CreatedAtAction(nameof(GetById), new { id = claim.Id }, claim);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(string id, Claim claim)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            claim.Id = id;
            await _service.UpdateAsync(id, claim);
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
