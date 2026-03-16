using ConnectPlus.API.Data;
using ConnectPlus.API.Models;
using ConnectPlus.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.API.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private readonly ApplicationDbContext _context;

        public AgentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Agent>> GetAllAsync()
        {
            return await _context.Agents.ToListAsync();
        }
    }
}