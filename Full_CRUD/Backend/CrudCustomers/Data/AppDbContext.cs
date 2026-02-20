using CrudCustomers.Models;
using Microsoft.EntityFrameworkCore;
using CrudCustomers.Models;
namespace CrudCustomers.Data
{
    

   
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {
            }

            public DbSet<Customer> Customers { get; set; }
        }
    

}
