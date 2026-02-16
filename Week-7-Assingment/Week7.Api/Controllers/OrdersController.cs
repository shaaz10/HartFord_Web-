using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerOrderAPIDemo.Models;
using CustomerOrderAPIDemo.Data;

namespace CustomerOrderAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders
                                 .Include(o => o.Customer)
                                 .ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders
                                      .Include(o => o.Customer)
                                      .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                return NotFound();

            return order;
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
                return BadRequest();

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // SPECIAL: Group Orders By Customer
        [HttpGet("grouped-by-customer")]
        public async Task<IActionResult> GetGroupedByCustomer()
        {
            var result = await _context.Orders
                .Include(o => o.Customer)
                .GroupBy(o => o.Customer.Name)
                .Select(g => new
                {
                    Customer = g.Key,
                    Orders = g.Select(o => new
                    {
                        o.Id,
                        o.OrderDate,
                        o.TotalAmount
                    })
                })
                .ToListAsync();

            return Ok(result);
        }
    }
}
