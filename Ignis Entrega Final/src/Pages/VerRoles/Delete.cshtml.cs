using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Models;

namespace Ignis.Pages.VerRoles
{
    public class DeleteModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public DeleteModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RoleWorker RoleWorker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? IdRoleWorker)
        {
            if (IdRoleWorker == null)
            {
                return NotFound();
            }

            RoleWorker = await _context.RoleWorker.FirstOrDefaultAsync(m => m.ID == IdRoleWorker);

            if (RoleWorker == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? IdRoleWorker)
        {
            if (IdRoleWorker == null)
            {
                return NotFound();
            }

            RoleWorker = await _context.RoleWorker.FindAsync(IdRoleWorker);

            if (RoleWorker != null)
            {
                _context.RoleWorker.Remove(RoleWorker);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
