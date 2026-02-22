using Hartford.Insurance.Api.Data;
using Hartford.Insurance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hartford.Insurance.Api.Services
{
    public class ClaimService : BaseService<Claim>
    {
        public ClaimService(AppDbContext db) : base(db) { }

        public async Task<List<Claim>> GetByCustomerIdAsync(int customerId)
            => await _set.Where(c => c.CustomerId == customerId).ToListAsync();

        public async Task<List<Claim>> GetByPolicyIdAsync(int policyId)
            => await _set.Where(c => c.PolicyId == policyId).ToListAsync();
    }
}
