using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/policyRecommendations")]
    [Authorize]
    public class PolicyRecommendationsController : ControllerBase
    {
        private readonly PolicyRecommendationService _service;
        public PolicyRecommendationsController(PolicyRecommendationService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<PolicyRecommendation>>> GetAll([FromQuery] int? requestId)
        {
            if (requestId.HasValue) return await _service.GetByRequestIdAsync(requestId.Value);
            return await _service.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PolicyRecommendation>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : result;
        }

        [HttpPost]
        [Authorize(Policy = "AgentOrAdmin")]
        public async Task<IActionResult> Create(PolicyRecommendation recommendation)
        {
            var created = await _service.CreateAsync(recommendation);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
