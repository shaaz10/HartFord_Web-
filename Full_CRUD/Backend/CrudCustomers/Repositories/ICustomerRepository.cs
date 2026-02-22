using CrudCustomers.Models;

namespace CrudCustomers.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(string id);
        Task<Customer> AddAsync(Customer customer);
        Task<Customer?> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(string id);
        Task<Feedback> AddFeedbackAsync(Feedback feedback);
    }
}



