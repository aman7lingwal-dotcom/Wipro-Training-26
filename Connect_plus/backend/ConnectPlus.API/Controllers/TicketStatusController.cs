using ConnectPlus.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketStatusController : ControllerBase
    {
        private readonly ITicketStatusService _ticketStatusService;

        public TicketStatusController(ITicketStatusService ticketStatusService)
        {
            _ticketStatusService = ticketStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStatuses()
        {
            var statuses = await _ticketStatusService.GetAllStatusesAsync();
            return Ok(statuses);
        }
    }
}