using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Data;
using MongoDB.Driver;

namespace Hartford.Insurance.Api.Services
{
    public class InsuranceRequestService : BaseService<InsuranceRequest>
    {
        public InsuranceRequestService(MongoDbContext context) : base(context.InsuranceRequests) { }

        public async Task<List<InsuranceRequest>> GetByCustomerIdAsync(string customerId)
        {
            return await _collection.Find(x => x.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<InsuranceRequest>> GetByAgentIdAsync(string agentId)
        {
            return await _collection.Find(x => x.AgentId == agentId).ToListAsync();
        }
    }
}
