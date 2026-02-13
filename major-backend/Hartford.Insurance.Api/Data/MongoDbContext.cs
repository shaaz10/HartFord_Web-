using Hartford.Insurance.Api.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Hartford.Insurance.Api.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDb");
            var databaseName = configuration.GetValue<string>("MongoDbSettings:DatabaseName");
            
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("users");
        public IMongoCollection<InsuranceRequest> InsuranceRequests => _database.GetCollection<InsuranceRequest>("insuranceRequests");
        public IMongoCollection<PolicyRecommendation> PolicyRecommendations => _database.GetCollection<PolicyRecommendation>("policyRecommendations");
        public IMongoCollection<PolicyApplication> PolicyApplications => _database.GetCollection<PolicyApplication>("policyApplications");
        public IMongoCollection<Policy> Policies => _database.GetCollection<Policy>("policies");
        public IMongoCollection<Claim> Claims => _database.GetCollection<Claim>("claims");
        public IMongoCollection<Agent> Agents => _database.GetCollection<Agent>("agents");
        public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>("customers");
        public IMongoCollection<Payment> Payments => _database.GetCollection<Payment>("payments");
        public IMongoCollection<Notification> Notifications => _database.GetCollection<Notification>("notifications");
    }
}
