using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hartford.Insurance.Api.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentService _service;
        public PaymentsController(PaymentService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<Payment>>> GetAll([FromQuery] int? policyId)
        {
            if (policyId.HasValue) return await _service.GetByPolicyIdAsync(policyId.Value);
            return await _service.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Payment>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : result;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Payment payment)
        {
            var created = await _service.CreateAsync(payment);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
