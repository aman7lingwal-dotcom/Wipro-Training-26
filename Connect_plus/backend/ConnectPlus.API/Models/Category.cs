using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectPlus.API.Models
{
    [Table("TicketCategories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public ICollection<Ticket>? Tickets { get; set; }
    }
}