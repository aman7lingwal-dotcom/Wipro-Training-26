using ConnectPlus.API.Models;

namespace ConnectPlus.API.Repositories.Interfaces
{
    public interface IAgentRepository
    {
        Task<IEnumerable<Agent>> GetAllAsync();
    }
}