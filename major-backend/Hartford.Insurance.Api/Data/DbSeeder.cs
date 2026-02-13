using Hartford.Insurance.Api.Models;
using MongoDB.Driver;

namespace Hartford.Insurance.Api.Data
{
    public class DbSeeder
    {
        private readonly MongoDbContext _context;

        public DbSeeder(MongoDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            // Check if users exist, if so, assume database is seeded
            if (await _context.Users.CountDocumentsAsync(_ => true) > 0) return;

            var users = new List<User>
            {
                new User { Email = "john.doe@example.com", Name = "John Doe", Role = "customer", PasswordHash = "hashed_pw_1" },
                new User { Email = "jane.smith@example.com", Name = "Jane Smith", Role = "agent", PasswordHash = "hashed_pw_2" },
                new User { Email = "admin@hartford.com", Name = "Admin User", Role = "admin", PasswordHash = "hashed_pw_3" }
            };
            await _context.Users.InsertManyAsync(users);
            
            var customerUser = users.First(u => u.Role == "customer");
            var agentUser = users.First(u => u.Role == "agent");

            var customers = new List<Customer>
            {
                new Customer { UserId = customerUser.Id, Name = "John Doe", Email = "john.doe@example.com", Phone = "555-0123", Address = "123 Main St" }
            };
            await _context.Customers.InsertManyAsync(customers);
            var customerId = customers[0].Id;

            var agents = new List<Agent>
            {
                new Agent { Name = "Jane Smith", Email = "jane.smith@example.com", Region = "Northeast" }
            };
            await _context.Agents.InsertManyAsync(agents);
            var agentId = agents[0].Id;

            var policies = new List<Policy>
            {
                new Policy { CustomerId = customerId, AgentId = agentId, PolicyName = "Standard Auto", Premium = 1200, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddYears(1) },
                new Policy { CustomerId = customerId, AgentId = agentId, PolicyName = "Home Insurance", Premium = 850, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddYears(1) }
            };
            await _context.Policies.InsertManyAsync(policies);

            var requests = new List<InsuranceRequest>
            {
                new InsuranceRequest { CustomerId = customerId, Type = "Life", Amount = 500000, Status = "Pending" },
                new InsuranceRequest { CustomerId = customerId, AgentId = agentId, Type = "Auto", Amount = 30000, Status = "Approved" }
            };
            await _context.InsuranceRequests.InsertManyAsync(requests);

            await _context.Notifications.InsertOneAsync(new Notification { UserId = customerUser.Id, Message = "Welcome to Hartford Insurance!", Date = DateTime.UtcNow });
        }
    }
}
