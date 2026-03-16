using ConnectPlus.API.Models;

namespace ConnectPlus.API.Services.Interfaces
{
    public interface ITicketStatusService
    {
        Task<IEnumerable<TicketStatus>> GetAllStatusesAsync();
    }
}