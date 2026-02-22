using Hartford.Insurance.Api.Data;
using Hartford.Insurance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hartford.Insurance.Api.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(AppDbContext db) : base(db) { }

        public async Task<User?> GetByEmailAsync(string email)
            => await _set.FirstOrDefaultAsync(u => u.Email == email);
    }
}
