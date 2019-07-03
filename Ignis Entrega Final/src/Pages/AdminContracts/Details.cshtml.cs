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
    public class DetailsModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public DetailsModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public Contract Contract { get; set; }

        public async Task<IActionResult> OnGetAsync(string IdClient, string IdTechnician)
        {
            if (IdClient == null || IdTechnician == null)
            {
                return NotFound();
            }

            Contract = await _context.Contract.Include(m => m.Client).Include(m => m.Technician)
            .FirstOrDefaultAsync(m => (m.ClientId == IdClient & m.TechnicianId == IdTechnician));

            if (Contract == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
