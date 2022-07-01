using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pro1;
using Pro1.Data;

namespace Pro1.Pages.Tickets
{
    [Authorize(Roles ="Seller")]
    public class IndexModel : PageModel
    {
        private readonly Pro1.Data.ApplicationDbContext _context;

        public IndexModel(Pro1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tickets != null)
            {
                Ticket = await _context.Tickets
                .Include(t => t.TicketCreator).ToListAsync();
            }
        }
    }
}
