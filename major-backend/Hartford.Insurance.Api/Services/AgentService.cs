using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Data;
using MongoDB.Driver;

namespace Hartford.Insurance.Api.Services
{
    public class AgentService : BaseService<Agent>
    {
        public AgentService(MongoDbContext context) : base(context.Agents) { }
    }
}
