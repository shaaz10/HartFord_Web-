using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/agents")]
    [Authorize(Policy = "AgentOrAdmin")]
    public class AgentsController : ControllerBase
    {
        private readonly AgentService _service;
        public AgentsController(AgentService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Agent>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Agent>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : result;
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Create(Agent agent)
        {
            var created = await _service.CreateAsync(agent);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id:int}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Update(int id, Agent agent)
        {
            var result = await _service.UpdateAsync(id, agent);
            return result == null ? NotFound() : NoContent();
        }
    }
}
