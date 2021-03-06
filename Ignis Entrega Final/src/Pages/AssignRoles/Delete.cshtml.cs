using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Models;

namespace Ignis.Pages.AssignRoles
{
    public class DeleteModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public DeleteModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Technician Tecnico { get; set; }

        public async Task<IActionResult> OnGetAsync(string IdTechnician)
        {
            if (IdTechnician == null)
            {
                return NotFound();
            }

            Tecnico = await _context.Technicians.FirstOrDefaultAsync(m => m.Id == IdTechnician);

            if (Tecnico == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string IdTechnician)
        {
            if (IdTechnician == null)
            {
                return NotFound();
            }

            Tecnico = await _context.Technicians.FindAsync(IdTechnician);

            if (Tecnico != null)
            {
                _context.Technicians.Remove(Tecnico);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
