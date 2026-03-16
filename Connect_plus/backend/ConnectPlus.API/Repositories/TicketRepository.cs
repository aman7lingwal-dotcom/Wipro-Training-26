using ConnectPlus.API.Data;
using ConnectPlus.API.DTOs;
using ConnectPlus.API.Models;
using ConnectPlus.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.API.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<IEnumerable<TicketDetailsDto>> GetAllTicketDetailsAsync()
        {
            return await _context.Tickets
                .Include(t => t.Customer)
                .Include(t => t.Category)
                .Include(t => t.Agent)
                .Include(t => t.TicketStatus)
                .Select(t => new TicketDetailsDto
                {
                    TicketId = t.TicketId,
                    CustomerName = t.Customer != null ? t.Customer.Name : string.Empty,
                    CategoryName = t.Category != null ? t.Category.CategoryName : string.Empty,
                    AgentName = t.Agent != null ? t.Agent.Name : string.Empty,
                    StatusName = t.TicketStatus != null ? t.TicketStatus.StatusName : string.Empty,
                    Description = t.Description,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt,
                    ResolutionNotes = t.ResolutionNotes
                })
                .ToListAsync();
                
        }
         public async Task AddTicketAsync(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> UpdateTicketAsync(Ticket ticket)
{
    var existingTicket = await _context.Tickets.FindAsync(ticket.TicketId);

    if (existingTicket == null)
    {
        return false;
    }

    existingTicket.CustomerId = ticket.CustomerId;
    existingTicket.CategoryId = ticket.CategoryId;
    existingTicket.AgentId = ticket.AgentId;
    existingTicket.StatusId = ticket.StatusId;
    existingTicket.Description = ticket.Description;
    existingTicket.ResolutionNotes = ticket.ResolutionNotes;
    existingTicket.UpdatedAt = DateTime.UtcNow;

    await _context.SaveChangesAsync();
    return true;
}
public async Task<Ticket?> GetTicketByIdAsync(int id)
{
    return await _context.Tickets.FindAsync(id);
}
    }
    
}