using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Areas.Identity.Data;

namespace RazorPagesMovie.Pages.Worker
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesMovie.Areas.Identity.Data.IdentityContext _context;

        public DeleteModel(RazorPagesMovie.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tecnico Tecnico { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tecnico = await _context.Tecnico.FirstOrDefaultAsync(m => m.Id == id);

            if (Tecnico == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tecnico = await _context.Tecnico.FindAsync(id);

            if (Tecnico != null)
            {
                _context.Tecnico.Remove(Tecnico);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
