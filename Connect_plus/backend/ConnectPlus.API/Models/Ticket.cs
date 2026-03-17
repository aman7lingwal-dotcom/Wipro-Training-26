using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectPlus.API.Models
{
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        public int CustomerId { get; set; }
        public int CategoryId { get; set; }
        public int AgentId { get; set; }
        public int StatusId { get; set; }

        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? ResolutionNotes { get; set; }

        public Customer? Customer { get; set; }
        public Category? Category { get; set; }
        public Agent? Agent { get; set; }
        public TicketStatus? TicketStatus { get; set; }
    }
}