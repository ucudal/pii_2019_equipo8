using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Areas.Identity.Data;
using Ignis.Models;

namespace Ignis.Pages_Consults
{
    public class IndexModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public Admin Admin { get; set; }
        public IList<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

        public async Task<IActionResult> OnGetAsync(string id)
        {
            string AdminEmail = User.Identity.Name;

            Admin = await _context.Admin.Include(m => m.Consults).Include(m => m.ListaTechnicians)
            .FirstOrDefaultAsync(m => m.Email == AdminEmail);

            foreach(Consults c in Admin.Consults)
            {
                ApplicationUser user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == c.UserID);
                Users.Add(user);
            }

            if (Admin == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}