using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pro1;
using Pro1.Data;

namespace Pro1.Pages.PurchaseTicket
{
    [Authorize(Roles ="Customer")]
    public class AvailableTicketsModel : PageModel
    {
        private readonly Pro1.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public AvailableTicketsModel(Pro1.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Ticket> Ticket { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tickets != null)
            {
                Ticket = await _context.Tickets
                .Include(t => t.TicketCreator).Where(a=>a.isPurchased==false).ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            string email = HttpContext.User.Identity.Name;

            var user = _userManager.Users.FirstOrDefault(a => a.UserName == email);

            var ticket = _context.Tickets.FirstOrDefault(a => a.Id == id);
            if(ticket!=null)
            {
                ticket.TicketBuyerId = user.Id;
                ticket.isPurchased = true;
                _context.Tickets.Update(ticket);
                await _context.SaveChangesAsync();
            }
            

            return RedirectToPage("./Index");
        }
    }
}
