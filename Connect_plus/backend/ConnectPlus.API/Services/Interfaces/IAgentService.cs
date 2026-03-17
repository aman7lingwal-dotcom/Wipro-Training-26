using ConnectPlus.API.Models;

namespace ConnectPlus.API.Services.Interfaces
{
    public interface IAgentService
    {
        Task<IEnumerable<Agent>> GetAllAgentsAsync();
    }
}