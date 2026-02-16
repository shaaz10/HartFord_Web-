using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week7.Api.Data;
using Week7.Api.Models;

namespace Week7.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _context.Customers
                .Include(c => c.Orders)
                .ToListAsync();

            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }
    }
}
