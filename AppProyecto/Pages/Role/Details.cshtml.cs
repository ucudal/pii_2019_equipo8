using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppProyecto.Models;

namespace AppProyecto.Pages.Role
{
    public class DetailsModel : PageModel
    {
        private readonly AppProyecto.Models.RazorPagesRoleContext _context;

        public DetailsModel(AppProyecto.Models.RazorPagesRoleContext context)
        {
            _context = context;
        }

        public AppProyecto.Models.Role Role { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Role = await _context.Role.FirstOrDefaultAsync(m => m.ID == id);

            if (Role == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
