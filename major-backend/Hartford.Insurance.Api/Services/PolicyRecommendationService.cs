using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Data;
using MongoDB.Driver;

namespace Hartford.Insurance.Api.Services
{
    public class PolicyRecommendationService : BaseService<PolicyRecommendation>
    {
        public PolicyRecommendationService(MongoDbContext context) : base(context.PolicyRecommendations) { }

        public async Task<List<PolicyRecommendation>> GetByRequestIdAsync(string requestId)
        {
            return await _collection.Find(x => x.RequestId == requestId).ToListAsync();
        }
    }
}
