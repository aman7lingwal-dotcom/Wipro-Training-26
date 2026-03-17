using ConnectPlus.API.Models;

namespace ConnectPlus.API.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task AddAsync(Customer customer);
    }
}