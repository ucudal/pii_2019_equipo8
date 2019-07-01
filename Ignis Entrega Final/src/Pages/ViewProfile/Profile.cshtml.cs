using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Ignis.Models;

namespace Ignis.Pages_ViewProfile
{
    public class ProfileModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;
        public ProfileModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }
        public ApplicationUser ApplicationUser { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string UserEmail = User.Identity.Name;
            ApplicationUser = await _context.Users.Include(m => m.Contracts).FirstOrDefaultAsync(m => m.Email == UserEmail);
            Technician t = await _context.Technicians.Include(r => r.WorkersWithRole).ThenInclude(r => r.RoleWorker)
            .FirstOrDefaultAsync(m => m.Email == UserEmail);
            if (t != null)
            {
                ApplicationUser = t;
            }
            
            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
