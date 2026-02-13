using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/policyRecommendations")]
    public class PolicyRecommendationsController : ControllerBase
    {
        private readonly PolicyRecommendationService _service;

        public PolicyRecommendationsController(PolicyRecommendationService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PolicyRecommendation>> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<List<PolicyRecommendation>>> GetAll([FromQuery] string? requestId)
        {
            if (!string.IsNullOrEmpty(requestId))
            {
                return await _service.GetByRequestIdAsync(requestId);
            }
            return await _service.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PolicyRecommendation recommendation)
        {
            await _service.CreateAsync(recommendation);
            return CreatedAtAction(nameof(GetById), new { id = recommendation.Id }, recommendation);
        }
    }
}
