using Hartford.Insurance.Api.Models;
using Hartford.Insurance.Api.Data;
using MongoDB.Driver;

namespace Hartford.Insurance.Api.Services
{
    public class CustomerService : BaseService<Customer>
    {
        public CustomerService(MongoDbContext context) : base(context.Customers) { }
    }
}
