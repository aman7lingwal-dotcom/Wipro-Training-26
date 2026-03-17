using ConnectPlus.API.Models;
using ConnectPlus.API.Repositories.Interfaces;
using ConnectPlus.API.Services.Interfaces;

namespace ConnectPlus.API.Services
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

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _repository.GetCustomerByIdAsync(id);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            customer.CreatedAt = DateTime.Now;
            await _repository.AddAsync(customer);
        }
    }
}