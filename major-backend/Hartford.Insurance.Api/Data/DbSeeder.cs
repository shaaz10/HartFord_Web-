using Hartford.Insurance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hartford.Insurance.Api.Data
{
    public class DbSeeder
    {
        private readonly AppDbContext _context;

        public DbSeeder(AppDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Apply any pending migrations automatically
            await _context.Database.MigrateAsync();

            // Check if already seeded with valid data
            if (await _context.Users.AnyAsync(u => u.PasswordHash.StartsWith("$2"))) return;

            // Clear stale data (no bcrypt hashes)
            _context.Users.RemoveRange(_context.Users.Where(u => !u.PasswordHash.StartsWith("$2")));
            await _context.SaveChangesAsync();

            // ── Users ──────────────────────────────────────────────────────────
            var customerUser = new User
            {
                Email = "customer@insurance.com",
                Name = "John Doe",
                Role = "customer",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123")
            };
            var agentUser = new User
            {
                Email = "agent@insurance.com",
                Name = "Jane Smith",
                Role = "agent",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("password123")
            };
            var adminUser = new User
            {
                Email = "admin@insurance.com",
                Name = "Admin User",
                Role = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123")
            };

            await _context.Users.AddRangeAsync(customerUser, agentUser, adminUser);
            await _context.SaveChangesAsync();

            // ── Customer & Agent records ───────────────────────────────────────
            var customer = new Customer
            {
                UserId = customerUser.Id,
                Name = "John Doe",
                Email = "customer@insurance.com",
                Phone = "555-0123",
                Address = "123 Main Street, Springfield"
            };
            var agent = new Agent
            {
                Name = "Jane Smith",
                Email = "agent@insurance.com",
                Region = "Northeast"
            };

            await _context.Customers.AddAsync(customer);
            await _context.Agents.AddAsync(agent);
            await _context.SaveChangesAsync();

            // ── Policies ───────────────────────────────────────────────────────
            var policy1 = new Policy
            {
                CustomerId = customer.Id,
                AgentId = agent.Id,
                PolicyName = "Standard Auto Insurance",
                Premium = 1200.00m,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddYears(1),
                Status = "Active"
            };
            var policy2 = new Policy
            {
                CustomerId = customer.Id,
                AgentId = agent.Id,
                PolicyName = "Home Insurance Premium",
                Premium = 850.00m,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddYears(1),
                Status = "Active"
            };

            await _context.Policies.AddRangeAsync(policy1, policy2);
            await _context.SaveChangesAsync();

            // ── Insurance Requests ─────────────────────────────────────────────
            var request1 = new InsuranceRequest
            {
                CustomerId = customer.Id,
                AgentId = agent.Id,
                Type = "Life",
                Amount = 500000.00m,
                Status = "Pending"
            };
            var request2 = new InsuranceRequest
            {
                CustomerId = customer.Id,
                AgentId = agent.Id,
                Type = "Auto",
                Amount = 30000.00m,
                Status = "Approved"
            };

            await _context.InsuranceRequests.AddRangeAsync(request1, request2);
            await _context.SaveChangesAsync();

            // ── Policy Recommendations ─────────────────────────────────────────
            await _context.PolicyRecommendations.AddRangeAsync(
                new PolicyRecommendation
                {
                    RequestId = request1.Id,
                    PolicyName = "Premium Life Cover",
                    Premium = 750.00m,
                    Coverage = "Up to ₹50,00,000"
                },
                new PolicyRecommendation
                {
                    RequestId = request2.Id,
                    PolicyName = "Comprehensive Auto",
                    Premium = 1200.00m,
                    Coverage = "Full damage + third-party"
                }
            );

            // ── Notifications ──────────────────────────────────────────────────
            await _context.Notifications.AddRangeAsync(
                new Notification { UserId = customerUser.Id, Message = "Welcome to Hartford Insurance!", Date = DateTime.UtcNow },
                new Notification { UserId = agentUser.Id, Message = "You have a new insurance request from John Doe.", Date = DateTime.UtcNow }
            );

            // ── Policy Application ─────────────────────────────────────────────
            await _context.PolicyApplications.AddAsync(new PolicyApplication
            {
                AgentId = agent.Id,
                CustomerId = customer.Id,
                PolicyName = "Term Life Insurance",
                Status = "Pending"
            });

            await _context.SaveChangesAsync();
        }
    }
}
