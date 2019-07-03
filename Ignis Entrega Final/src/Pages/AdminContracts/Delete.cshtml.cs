using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Areas.Identity.Data;
using Ignis.Models;

namespace Ignis.Pages_AdminContracts
{
    public class DeleteModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public DeleteModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contract Contract { get; set; }

        public async Task<IActionResult> OnGetAsync(string id1, string id2)
        {
            try
            {
                Check.Precondition(id1 != null & id2 != null, "La pagina no se encontro");
            }
            catch (Check.PreconditionException ex)
            {
                return Redirect("https://localhost:5001/Exception/Exception?id=" + ex.Message);
            }

            Contract = await _context.Contract.Include(c => c.Client).Include(c => c.Technician)
            .FirstOrDefaultAsync(m => (m.ClientId == id1 & m.TechnicianId == id2));

            if (Contract == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Contract = await _context.Contract
            .FirstOrDefaultAsync(m => (m.ClientId == Contract.ClientId & m.TechnicianId == Contract.TechnicianId));

            if (Contract != null)
            {
                _context.Contract.Remove(Contract);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
