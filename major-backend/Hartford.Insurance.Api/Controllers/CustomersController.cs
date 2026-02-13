using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomersController(CustomerService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAll()
        {
            return await _service.GetAllAsync();
        }
    }
}
