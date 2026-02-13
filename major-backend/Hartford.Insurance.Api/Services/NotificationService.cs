using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Data;
using MongoDB.Driver;

namespace Hartford.Insurance.Api.Services
{
    public class NotificationService : BaseService<Notification>
    {
        public NotificationService(MongoDbContext context) : base(context.Notifications) { }

        public async Task<List<Notification>> GetByUserIdAsync(string userId)
        {
            return await _collection.Find(x => x.UserId == userId).ToListAsync();
        }
    }
}
