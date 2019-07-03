using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Ignis.Models;

namespace Ignis.Areas.Identity.Pages.Users
{
    [Authorize(Roles=IdentityData.AdminRoleName)] // Solo los usuarios con rol administrador pueden acceder a este controlador
    public class DetailsModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public DetailsModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            try
            {
                Check.Precondition(id != null, "No se encontro la pagina");
            }
            catch (Check.PreconditionException ex)
            {
                return Redirect("https://localhost:5001/Exception/Exception?id=" + ex.Message);
            }

            ApplicationUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            try
            {
                Check.Postcondition(ApplicationUser != null, "No se encontro el usuario");
            }
            catch (Check.PostconditionException ex)
            {
                return Redirect("https://localhost:5001/Exception/Exception?id=" + ex.Message);
            }

            return Page();
        }
    }
}
