using CrudCustomers.Models;
using CrudCustomers.Repositories;
using CrudCustomers.Models;
using CrudCustomers.Repositories;
namespace CrudCustomers.Services
{
    

   
        public class CustomerService : ICustomerService
        {
            private readonly ICustomerRepository _repository;

            public CustomerService(ICustomerRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
            {
                return await _repository.GetAllAsync();
            }

            public async Task<Customer?> GetCustomerByIdAsync(string id)
            {
                return await _repository.GetByIdAsync(id);
            }

            public async Task<Customer> CreateCustomerAsync(Customer customer)
            {
                return await _repository.AddAsync(customer);
            }

            public async Task<Customer?> UpdateCustomerAsync(string id, Customer customer)
            {
                if (id != customer.Id)
                    return null;

                return await _repository.UpdateAsync(customer);
            }

            public async Task<bool> DeleteCustomerAsync(string id)
            {
                return await _repository.DeleteAsync(id);
            }
        }
    }


