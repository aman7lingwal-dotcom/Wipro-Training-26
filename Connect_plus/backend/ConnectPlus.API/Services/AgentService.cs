using ConnectPlus.API.Models;
using ConnectPlus.API.Repositories.Interfaces;
using ConnectPlus.API.Services.Interfaces;

namespace ConnectPlus.API.Services
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _repository;

        public AgentService(IAgentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Agent>> GetAllAgentsAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}