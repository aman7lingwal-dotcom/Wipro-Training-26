using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectPlus.API.Models
{
    [Table("Agents")]
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public ICollection<Ticket>? Tickets { get; set; }
    }
}