using Hartford.Insurance.Api.Data;
using Hartford.Insurance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hartford.Insurance.Api.Services
{
    public class PolicyApplicationService : BaseService<PolicyApplication>
    {
        public PolicyApplicationService(AppDbContext db) : base(db) { }

        public async Task<List<PolicyApplication>> GetByAgentIdAsync(int agentId)
            => await _set.Where(a => a.AgentId == agentId).ToListAsync();

        public async Task<List<PolicyApplication>> GetByCustomerIdAsync(int customerId)
            => await _set.Where(a => a.CustomerId == customerId).ToListAsync();
    }
}
