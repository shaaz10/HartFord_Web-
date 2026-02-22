using Hartford.Insurance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hartford.Insurance.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Agent> Agents => Set<Agent>();
        public DbSet<Policy> Policies => Set<Policy>();
        public DbSet<Claim> Claims => Set<Claim>();
        public DbSet<InsuranceRequest> InsuranceRequests => Set<InsuranceRequest>();
        public DbSet<PolicyRecommendation> PolicyRecommendations => Set<PolicyRecommendation>();
        public DbSet<PolicyApplication> PolicyApplications => Set<PolicyApplication>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Notification> Notifications => Set<Notification>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ── User ──────────────────────────────────────────────────────────
            modelBuilder.Entity<User>(e =>
            {
                e.HasIndex(u => u.Email).IsUnique();
                e.Property(u => u.Email).HasMaxLength(256).IsRequired();
                e.Property(u => u.Name).HasMaxLength(200).IsRequired();
                e.Property(u => u.Role).HasMaxLength(50).IsRequired();
                e.Property(u => u.PasswordHash).IsRequired();
            });

            // ── Customer ──────────────────────────────────────────────────────
            modelBuilder.Entity<Customer>(e =>
            {
                e.Property(c => c.Name).HasMaxLength(200).IsRequired();
                e.Property(c => c.Email).HasMaxLength(256);
                e.Property(c => c.Phone).HasMaxLength(50);
                e.Property(c => c.Address).HasMaxLength(500);
                e.HasOne(c => c.User).WithMany().HasForeignKey(c => c.UserId)
                 .OnDelete(DeleteBehavior.SetNull);
            });

            // ── Agent ─────────────────────────────────────────────────────────
            modelBuilder.Entity<Agent>(e =>
            {
                e.Property(a => a.Name).HasMaxLength(200).IsRequired();
                e.Property(a => a.Email).HasMaxLength(256);
                e.Property(a => a.Region).HasMaxLength(100);
            });

            // ── Policy ────────────────────────────────────────────────────────
            modelBuilder.Entity<Policy>(e =>
            {
                e.Property(p => p.PolicyName).HasMaxLength(200).IsRequired();
                e.Property(p => p.Premium).HasColumnType("decimal(18,2)");
                e.Property(p => p.Status).HasMaxLength(50);
                e.HasOne(p => p.Customer).WithMany().HasForeignKey(p => p.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(p => p.Agent).WithMany().HasForeignKey(p => p.AgentId)
                 .OnDelete(DeleteBehavior.SetNull);
            });

            // ── Claim ─────────────────────────────────────────────────────────
            modelBuilder.Entity<Claim>(e =>
            {
                e.Property(c => c.Amount).HasColumnType("decimal(18,2)");
                e.Property(c => c.Status).HasMaxLength(50);
                e.Property(c => c.Description).HasMaxLength(1000);
                e.HasOne(c => c.Customer).WithMany().HasForeignKey(c => c.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(c => c.Policy).WithMany().HasForeignKey(c => c.PolicyId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // ── InsuranceRequest ──────────────────────────────────────────────
            modelBuilder.Entity<InsuranceRequest>(e =>
            {
                e.Property(r => r.Amount).HasColumnType("decimal(18,2)");
                e.Property(r => r.Status).HasMaxLength(50);
                e.Property(r => r.Type).HasMaxLength(100);
                e.HasOne(r => r.Customer).WithMany().HasForeignKey(r => r.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(r => r.Agent).WithMany().HasForeignKey(r => r.AgentId)
                 .OnDelete(DeleteBehavior.SetNull);
            });

            // ── PolicyRecommendation ──────────────────────────────────────────
            modelBuilder.Entity<PolicyRecommendation>(e =>
            {
                e.Property(r => r.Premium).HasColumnType("decimal(18,2)");
                e.Property(r => r.PolicyName).HasMaxLength(200);
                e.Property(r => r.Coverage).HasMaxLength(500);
                e.HasOne(r => r.Request).WithMany().HasForeignKey(r => r.RequestId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // ── PolicyApplication ─────────────────────────────────────────────
            modelBuilder.Entity<PolicyApplication>(e =>
            {
                e.Property(a => a.PolicyName).HasMaxLength(200);
                e.Property(a => a.Status).HasMaxLength(50);
                e.HasOne(a => a.Agent).WithMany().HasForeignKey(a => a.AgentId)
                 .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(a => a.Customer).WithMany().HasForeignKey(a => a.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // ── Payment ───────────────────────────────────────────────────────
            modelBuilder.Entity<Payment>(e =>
            {
                e.Property(p => p.Amount).HasColumnType("decimal(18,2)");
                e.Property(p => p.Method).HasMaxLength(100);
                e.HasOne(p => p.Policy).WithMany().HasForeignKey(p => p.PolicyId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // ── Notification ──────────────────────────────────────────────────
            modelBuilder.Entity<Notification>(e =>
            {
                e.Property(n => n.Message).HasMaxLength(1000);
                e.HasOne(n => n.User).WithMany().HasForeignKey(n => n.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
