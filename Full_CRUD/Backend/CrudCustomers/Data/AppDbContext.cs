using CrudCustomers.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrudCustomers.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(b =>
            {
                b.HasKey(c => c.Id);
                b.HasMany<Feedback>().WithOne().HasForeignKey(f => f.CustomerId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Feedback>(b =>
            {
                b.HasKey(f => f.Id);
            });
        }
    }
}
