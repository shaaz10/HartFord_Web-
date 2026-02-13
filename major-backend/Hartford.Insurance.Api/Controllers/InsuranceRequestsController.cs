using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/insuranceRequests")]
    public class InsuranceRequestsController : ControllerBase
    {
        private readonly InsuranceRequestService _service;

        public InsuranceRequestsController(InsuranceRequestService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceRequest>> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<List<InsuranceRequest>>> GetAll([FromQuery] string? customerId, [FromQuery] string? agentId)
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
        public async Task<IActionResult> Create(InsuranceRequest request)
        {
            await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = request.Id }, request);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(string id, InsuranceRequest request)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            request.Id = id;
            await _service.UpdateAsync(id, request);
            return NoContent();
        }
    }
}
