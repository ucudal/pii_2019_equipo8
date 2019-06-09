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
    public class DetailsModel : PageModel
    {
        private readonly Ignis.Models.IgnisContext _context;

        public DetailsModel(Ignis.Models.IgnisContext context)
        {
            _context = context;
        }

        public RoleWorker RoleWorker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RoleWorker = await _context.RoleWorker.FirstOrDefaultAsync(m => m.ID == id);

            if (RoleWorker == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
