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
    [Authorize(Roles = "Customer")]
    public class MyTicketsModel : PageModel
    {
        private readonly Pro1.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MyTicketsModel(Pro1.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Ticket> Ticket { get;set; } = default!;

        public async Task OnGetAsync()
        {
            string email = HttpContext.User.Identity.Name;

            var user = _userManager.Users.FirstOrDefault(a => a.UserName == email);
            if (_context.Tickets != null)
            {
                Ticket = await _context.Tickets
                .Include(t => t.TicketBuyer)
                .Include(t => t.TicketCreator)
                .Where(a=>a.TicketBuyerId.Equals(user.Id) && a.isPurchased==true).ToListAsync();
            }
        }
    }
}
