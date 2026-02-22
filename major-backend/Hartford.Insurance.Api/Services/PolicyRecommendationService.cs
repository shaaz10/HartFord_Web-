using Hartford.Insurance.Api.Data;
using Hartford.Insurance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hartford.Insurance.Api.Services
{
    public class PolicyRecommendationService : BaseService<PolicyRecommendation>
    {
        public PolicyRecommendationService(AppDbContext db) : base(db) { }

        public async Task<List<PolicyRecommendation>> GetByRequestIdAsync(int requestId)
            => await _set.Where(r => r.RequestId == requestId).ToListAsync();
    }
}
