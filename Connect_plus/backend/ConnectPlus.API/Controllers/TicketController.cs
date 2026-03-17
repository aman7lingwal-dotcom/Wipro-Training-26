using ConnectPlus.API.Models;
using ConnectPlus.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return Ok(tickets);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetAllTicketDetails()
        {
            var tickets = await _ticketService.GetAllTicketDetailsAsync();
            return Ok(tickets);
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket([FromBody] Ticket ticket)
        {
            ticket.CreatedAt = DateTime.UtcNow;
            ticket.UpdatedAt = DateTime.UtcNow;

            await _ticketService.AddTicketAsync(ticket);

            return Ok(ticket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.TicketId)
            {
                return BadRequest("Ticket ID mismatch.");
            }

            var updated = await _ticketService.UpdateTicketAsync(ticket);

            if (!updated)
            {
                return NotFound("Ticket not found.");
            }

            return NoContent();
        }
    [HttpGet("{id}")]
public async Task<IActionResult> GetTicketById(int id)
{
    var ticket = await _ticketService.GetTicketByIdAsync(id);

    if (ticket == null)
    {
        return NotFound();
    }

    return Ok(ticket);
}
    }
}