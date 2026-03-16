using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectPlus.API.Models
{
    [Table("TicketStatus")]
    public class TicketStatus
    {
        [Key]
        public int StatusId { get; set; }

        public string StatusName { get; set; } = string.Empty;

        public ICollection<Ticket>? Tickets { get; set; }
    }
}