using ConnectPlus.API.DTOs;
using ConnectPlus.API.Models;

namespace ConnectPlus.API.Services.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<IEnumerable<TicketDetailsDto>> GetAllTicketDetailsAsync();

        Task AddTicketAsync(Ticket ticket);
       
Task<bool> UpdateTicketAsync(Ticket ticket);
Task<Ticket?> GetTicketByIdAsync(int id);
    }
}
