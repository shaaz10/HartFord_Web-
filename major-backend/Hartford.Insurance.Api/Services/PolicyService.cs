using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Data;
using MongoDB.Driver;

namespace Hartford.Insurance.Api.Services
{
    public class PolicyService : BaseService<Policy>
    {
        public PolicyService(MongoDbContext context) : base(context.Policies) { }

        public async Task<List<Policy>> GetByCustomerIdAsync(string customerId)
        {
            return await _collection.Find(x => x.CustomerId == customerId).ToListAsync();
        }


        public async Task<List<Policy>> GetByAgentIdAsync(string agentId)
        {
            return await _collection.Find(x => x.AgentId == agentId).ToListAsync();
        }
    }
}
