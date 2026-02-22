using Hartford.Insurance.Api.Data;
using Hartford.Insurance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hartford.Insurance.Api.Services
{
    public class NotificationService : BaseService<Notification>
    {
        public NotificationService(AppDbContext db) : base(db) { }

        public async Task<List<Notification>> GetByUserIdAsync(int userId)
            => await _set.Where(n => n.UserId == userId).ToListAsync();
    }
}
