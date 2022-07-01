using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Pro1
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        public string TicketName { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int Price { get; set; }
        public bool isPurchased { get; set; }
        public IdentityUser TicketCreator { get; set; }
        public string TicketCreatorId { get; set; }
    }

    public class PuchasedTicket
    {
        public int Id { get; set; }
        public IdentityUser TicketOwner { get; set; }
        public string TicketOwnerId { get; set; }
    }
}
