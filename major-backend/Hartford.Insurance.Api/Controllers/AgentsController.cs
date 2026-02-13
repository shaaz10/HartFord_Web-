using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/agents")]
    public class AgentsController : ControllerBase
    {
        private readonly AgentService _service;

        public AgentsController(AgentService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agent>> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<List<Agent>>> GetAll()
        {
            return await _service.GetAllAsync();
        }
    }
}
