using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pro1;
using Pro1.Data;

namespace Pro1.Pages.Tickets
{
    [Authorize(Roles = "Seller")]
    public class CreateModel : PageModel
    {

        private readonly Pro1.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(Pro1.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            ViewData["TicketCreatorId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            string email = HttpContext.User.Identity.Name;

            var user = _userManager.Users.FirstOrDefault(a => a.UserName == email);

            Ticket.TicketCreatorId = user.Id;
            ModelState.Remove("Ticket.TicketCreator");
            ModelState.Remove("Ticket.TicketCreatorId");
            //if (!ModelState.IsValid || _context.Tickets == null || Ticket == null)
            //{
            //    return Page();
            //}

            _context.Tickets.Add(Ticket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
