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
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public DetailsModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public RoleWorker RoleWorker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? IdRoleWorker)
        {
            try
            {
                Check.Precondition(IdRoleWorker != null, "La pagina no se encontro");
            }
            catch (Check.PreconditionException ex)
            {
                return Redirect("https://localhost:5001/Exception/Exception?id=" + ex.Message);
            }

            RoleWorker = await _context.RoleWorker.FirstOrDefaultAsync(m => m.ID == IdRoleWorker);

            if (RoleWorker == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
