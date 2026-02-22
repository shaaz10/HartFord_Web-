using Hartford.Insurance.Api.Data;
using Hartford.Insurance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hartford.Insurance.Api.Services
{
    public class PolicyService : BaseService<Policy>
    {
        public PolicyService(AppDbContext db) : base(db) { }

        public async Task<List<Policy>> GetByCustomerIdAsync(int customerId)
            => await _set.Where(p => p.CustomerId == customerId).ToListAsync();

        public async Task<List<Policy>> GetByAgentIdAsync(int agentId)
            => await _set.Where(p => p.AgentId == agentId).ToListAsync();
    }
}
