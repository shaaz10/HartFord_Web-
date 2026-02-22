using Hartford.Insurance.Api.Data;
using Hartford.Insurance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hartford.Insurance.Api.Services
{
    public class CustomerService : BaseService<Customer>
    {
        public CustomerService(AppDbContext db) : base(db) { }

        public async Task<Customer?> GetByUserIdAsync(int userId)
            => await _set.FirstOrDefaultAsync(c => c.UserId == userId);
    }
}
