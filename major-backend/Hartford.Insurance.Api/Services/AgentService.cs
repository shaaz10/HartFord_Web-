using Hartford.Insurance.Api.Data;
using Hartford.Insurance.Api.Models;

namespace Hartford.Insurance.Api.Services
{
    public class AgentService : BaseService<Agent>
    {
        public AgentService(AppDbContext db) : base(db) { }
    }
}
