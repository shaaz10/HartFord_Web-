using Hartford.Insurance.Api.Data;
using Hartford.Insurance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hartford.Insurance.Api.Services
{
    public class PaymentService : BaseService<Payment>
    {
        public PaymentService(AppDbContext db) : base(db) { }

        public async Task<List<Payment>> GetByPolicyIdAsync(int policyId)
            => await _set.Where(p => p.PolicyId == policyId).ToListAsync();
    }
}
