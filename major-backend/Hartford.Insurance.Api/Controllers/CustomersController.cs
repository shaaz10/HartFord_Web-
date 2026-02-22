using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _service;
        public CustomersController(CustomerService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAll() => await _service.GetAllAsync();

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : result;
        }

        [HttpPost]
        [Authorize(Policy = "AgentOrAdmin")]
        public async Task<IActionResult> Create(Customer customer)
        {
            var created = await _service.CreateAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id:int}")]
        [Authorize(Policy = "AgentOrAdmin")]
        public async Task<IActionResult> Update(int id, Customer customer)
        {
            var result = await _service.UpdateAsync(id, customer);
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
