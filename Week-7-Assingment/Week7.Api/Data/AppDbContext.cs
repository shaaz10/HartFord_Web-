using Microsoft.EntityFrameworkCore;
using CustomerOrderAPIDemo.Models;

namespace CustomerOrderAPIDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
