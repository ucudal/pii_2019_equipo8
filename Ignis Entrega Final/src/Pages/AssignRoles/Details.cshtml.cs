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
    public class DetailsModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public DetailsModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public Technician Technician { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Technician = await _context.Technicians.FirstOrDefaultAsync(m => m.Id == id);

            if (Technician == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
