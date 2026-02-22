using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/insuranceRequests")]
    [Authorize]
    public class InsuranceRequestsController : ControllerBase
    {
        private readonly InsuranceRequestService _service;
        public InsuranceRequestsController(InsuranceRequestService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<InsuranceRequest>>> GetAll(
            [FromQuery] int? customerId,
            [FromQuery] int? agentId)
        {
            if (customerId.HasValue) return await _service.GetByCustomerIdAsync(customerId.Value);
            if (agentId.HasValue)    return await _service.GetByAgentIdAsync(agentId.Value);
            return await _service.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InsuranceRequest>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : result;
        }

        [HttpPost]
        public async Task<IActionResult> Create(InsuranceRequest request)
        {
            var created = await _service.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id:int}")]
        [Authorize(Policy = "AgentOrAdmin")]
        public async Task<IActionResult> Update(int id, InsuranceRequest request)
        {
            var result = await _service.UpdateAsync(id, request);
            return result == null ? NotFound() : NoContent();
        }
    }
}
