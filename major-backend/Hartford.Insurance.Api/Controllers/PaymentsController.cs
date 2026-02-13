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

        public PaymentsController(PaymentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Payment payment)
        {
            await _service.CreateAsync(payment);
            // Typically redirect to GET but GET is not requested. So just 201 Created with body or empty location?
            // CreatedAtAction requires an action name.
            // Since there is no GetById, just return Created? Or Ok.
            // 201 Created is better. Location header might be just "api/payments/{id}" even if not impl.
            return Created($"api/payments/{payment.Id}", payment);
        }
    }
}
