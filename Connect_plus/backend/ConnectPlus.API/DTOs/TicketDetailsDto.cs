namespace ConnectPlus.API.DTOs
{
    public class TicketDetailsDto
    {
        public int TicketId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string AgentName { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? ResolutionNotes { get; set; }
    }
}