using ConnectPlus.API.Models;

namespace ConnectPlus.API.Repositories.Interfaces
{
    public interface ITicketStatusRepository
    {
        Task<IEnumerable<TicketStatus>> GetAllAsync();
    }
}