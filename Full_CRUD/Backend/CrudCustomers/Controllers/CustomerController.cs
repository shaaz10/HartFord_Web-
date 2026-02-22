using Microsoft.AspNetCore.Mvc;
using CrudCustomers.Models;
using CrudCustomers.Services;
using Microsoft.AspNetCore.Mvc;
using CrudCustomers.Models;
using CrudCustomers.Services;

namespace CrudCustomers.Controllers
{
  

  
        [Route("api/[controller]")]
        [ApiController]
        public class CustomerController : ControllerBase
        {
            private readonly ICustomerService _service;

            public CustomerController(ICustomerService service)
            {
                _service = service;
            }

            // GET: api/customer
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var customers = await _service.GetAllCustomersAsync();
                return Ok(customers);
            }

            // GET: api/customer/5
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(string id)
            {
                var customer = await _service.GetCustomerByIdAsync(id);

                if (customer == null)
                    return NotFound("Customer not found");

                return Ok(customer);
            }

            // POST: api/customer
            [HttpPost]
            public async Task<IActionResult> Create(Customer customer)
            {
                var createdCustomer = await _service.CreateCustomerAsync(customer);

                return CreatedAtAction(nameof(GetById),
                    new { id = createdCustomer.Id },
                    createdCustomer);
            }

            // PUT: api/customer/5
            [HttpPut("{id}")]
            public async Task<IActionResult> Update(string id, Customer customer)
            {
                var updatedCustomer = await _service.UpdateCustomerAsync(id, customer);

                if (updatedCustomer == null)
                    return BadRequest("Invalid update request");

                return Ok(updatedCustomer);
            }

            // DELETE: api/customer/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(string id)
            {
                var deleted = await _service.DeleteCustomerAsync(id);

                if (!deleted)
                    return NotFound("Customer not found");

                return NoContent();
            }
        }
    }


