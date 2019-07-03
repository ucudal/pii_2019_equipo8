using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ignis.Models;

namespace Ignis.Pages.VerRoles
{
    public class EditModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public EditModel(Ignis.Areas.Identity.Data.IdentityContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RoleWorker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleWorkerExists(RoleWorker.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RoleWorkerExists(int IdRoleWorker)
        {
            return _context.RoleWorker.Any(e => e.ID == IdRoleWorker);
        }
    }
}
