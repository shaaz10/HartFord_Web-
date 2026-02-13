using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Data;
using MongoDB.Driver;

namespace Hartford.Insurance.Api.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(MongoDbContext context) : base(context.Users) { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _collection.Find(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
