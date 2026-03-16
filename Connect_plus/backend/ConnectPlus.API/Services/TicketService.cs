using ConnectPlus.API.DTOs;
using ConnectPlus.API.Models;
using ConnectPlus.API.Repositories.Interfaces;
using ConnectPlus.API.Services.Interfaces;

namespace ConnectPlus.API.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;

        public TicketService(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<TicketDetailsDto>> GetAllTicketDetailsAsync()
        {
            return await _repository.GetAllTicketDetailsAsync();
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            await _repository.AddTicketAsync(ticket);
        }
        public async Task<bool> UpdateTicketAsync(Ticket ticket)
{
    return await _repository.UpdateTicketAsync(ticket);
}
public async Task<Ticket?> GetTicketByIdAsync(int id)
{
    return await _repository.GetTicketByIdAsync(id);
}
    }
}
