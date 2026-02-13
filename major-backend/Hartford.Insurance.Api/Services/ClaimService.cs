using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Data;
using MongoDB.Driver;

namespace Hartford.Insurance.Api.Services
{
    public class ClaimService : BaseService<Claim>
    {
        public ClaimService(MongoDbContext context) : base(context.Claims) { }

        public async Task<List<Claim>> GetByCustomerIdAsync(string customerId)
        {
            return await _collection.Find(x => x.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<Claim>> GetByPolicyIdAsync(string policyId)
        {
            return await _collection.Find(x => x.PolicyId == policyId).ToListAsync();
        }
    }
}
