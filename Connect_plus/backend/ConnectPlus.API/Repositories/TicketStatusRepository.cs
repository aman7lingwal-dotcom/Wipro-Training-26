using ConnectPlus.API.Data;
using ConnectPlus.API.Models;
using ConnectPlus.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.API.Repositories
{
    public class TicketStatusRepository : ITicketStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TicketStatus>> GetAllAsync()
        {
            return await _context.TicketStatuses.ToListAsync();
        }
    }
}