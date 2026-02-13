using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Data;
using MongoDB.Driver;

namespace Hartford.Insurance.Api.Services
{
    public class PaymentService : BaseService<Payment>
    {
        public PaymentService(MongoDbContext context) : base(context.Payments) { }
    }
}
