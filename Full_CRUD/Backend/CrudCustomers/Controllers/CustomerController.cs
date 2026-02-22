using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CrudCustomers.Models;
using CrudCustomers.Services;
using System.Security.Claims;

namespace CrudCustomers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        // GET: api/customer
        [HttpGet]
        [Authorize(Roles = "User,Manager,Admin")]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _service.GetAllCustomersAsync();
            return Ok(customers);
        }

        // GET: api/customer/5
        [HttpGet("{id}")]
        [Authorize(Roles = "User,Manager,Admin")]
        public async Task<IActionResult> GetById(string id)
        {
            var customer = await _service.GetCustomerByIdAsync(id);

            if (customer == null)
                return NotFound("Customer not found");

            return Ok(customer);
        }

        // POST: api/customer
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Customer customer)
        {
            var createdCustomer = await _service.CreateCustomerAsync(customer);

            return CreatedAtAction(nameof(GetById),
                new { id = createdCustomer.Id },
                createdCustomer);
        }

        // PUT: api/customer/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Manager,Admin")]
        public async Task<IActionResult> Update(string id, Customer customer)
        {
            var existing = await _service.GetCustomerByIdAsync(id);
            if (existing == null) return NotFound("Customer not found");

            if (User.IsInRole("Admin"))
            {
                if (id != customer.Id) return BadRequest("Id mismatch");
                var updatedCustomer = await _service.UpdateCustomerAsync(id, customer);
                if (updatedCustomer == null)
                    return BadRequest("Invalid update request");

                return Ok(updatedCustomer);
            }

            // Manager limited updates
            if (User.IsInRole("Manager"))
            {
                existing.Name = customer.Name;
                existing.Email = customer.Email;
                existing.Phone = customer.Phone;
                var updatedCustomer = await _service.UpdateCustomerAsync(id, existing);
                if (updatedCustomer == null)
                    return BadRequest("Invalid update request");

                return Ok(updatedCustomer);
            }

            return Forbid();
        }

        // DELETE: api/customer/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _service.DeleteCustomerAsync(id);

            if (!deleted)
                return NotFound("Customer not found");

            return NoContent();
        }

        // POST: api/customer/5/feedback
        [HttpPost("{id}/feedback")]
        [Authorize(Roles = "Manager,Admin")]
        public async Task<IActionResult> AddFeedback(string id, [FromBody] FeedbackDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            var feedback = new Feedback
            {
                Id = Guid.NewGuid().ToString(),
                CustomerId = id,
                ManagerId = userId,
                Comment = dto.Comment,
                CreatedAt = DateTime.UtcNow
            };

            var saved = await _service.AddFeedbackAsync(feedback);
            return Ok(saved);
        }

        public record FeedbackDto(string Comment);
    }
}


