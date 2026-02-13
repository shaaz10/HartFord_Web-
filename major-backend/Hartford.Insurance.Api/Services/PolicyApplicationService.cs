using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Data;
using MongoDB.Driver;

namespace Hartford.Insurance.Api.Services
{
    public class PolicyApplicationService : BaseService<PolicyApplication>
    {
        public PolicyApplicationService(MongoDbContext context) : base(context.PolicyApplications) { }

        public async Task<List<PolicyApplication>> GetByAgentIdAsync(string agentId)
        {
            return await _collection.Find(x => x.AgentId == agentId).ToListAsync();
        }
    }
}
