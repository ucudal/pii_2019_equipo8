using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Areas.Identity.Data;
using Ignis.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ignis.Pages_Contracts
{
    public class IndexModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string username = User.Identity.Name;
            foreach(ApplicationUser c in _context.Users)
            {
                if (c.Email == username)
                {
                    ApplicationUser = c;
                }
            }
            ApplicationUser = await _context.Users.Include(c =>c.Contracts).FirstOrDefaultAsync(m => m.Id == ApplicationUser.Id);

            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
