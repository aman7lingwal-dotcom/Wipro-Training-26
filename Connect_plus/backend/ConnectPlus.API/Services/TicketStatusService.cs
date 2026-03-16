using ConnectPlus.API.Models;
using ConnectPlus.API.Repositories.Interfaces;
using ConnectPlus.API.Services.Interfaces;

namespace ConnectPlus.API.Services
{
    public class TicketStatusService : ITicketStatusService
    {
        private readonly ITicketStatusRepository _repository;

        public TicketStatusService(ITicketStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TicketStatus>> GetAllStatusesAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}