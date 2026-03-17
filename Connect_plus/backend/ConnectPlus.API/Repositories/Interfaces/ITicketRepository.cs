using ConnectPlus.API.DTOs;
using ConnectPlus.API.Models;

namespace ConnectPlus.API.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task<IEnumerable<TicketDetailsDto>> GetAllTicketDetailsAsync();
        Task AddTicketAsync(Ticket ticket);
       
Task<bool> UpdateTicketAsync(Ticket ticket);
Task<Ticket?> GetTicketByIdAsync(int id);
    }
}