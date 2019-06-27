using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Areas.Identity.Data;
using Ignis.Models;

namespace Ignis.Pages_Responses
{
    public class IndexModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            string UserEmail = User.Identity.Name;

            ApplicationUser = await _context.Users.FirstOrDefaultAsync(m => m.Email == UserEmail);

            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}