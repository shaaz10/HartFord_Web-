using Hartford.Insurance.Api.Data;
using Hartford.Insurance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hartford.Insurance.Api.Services
{
    public class InsuranceRequestService : BaseService<InsuranceRequest>
    {
        public InsuranceRequestService(AppDbContext db) : base(db) { }

        public async Task<List<InsuranceRequest>> GetByCustomerIdAsync(int customerId)
            => await _set.Where(r => r.CustomerId == customerId).ToListAsync();

        public async Task<List<InsuranceRequest>> GetByAgentIdAsync(int agentId)
            => await _set.Where(r => r.AgentId == agentId).ToListAsync();
    }
}
