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

namespace Ignis.Pages_ViewProfile
{
    public class ProfileModel : PageModel
    {
        private readonly IdentityContext _context;
        public ProfileModel(IdentityContext context)
        {
            _context = context;
        }
        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Obtengo el Username del usuario que esta navegando
            string UserEmail = User.Identity.Name;
            ApplicationUser = await _context.Users.Include(m => m.Contracts)
            .FirstOrDefaultAsync(m => m.Email == UserEmail);

            // Si el usuario es un tecnico hay que traer de la base de datos los roles
            // para que se puedan mostrar
            Technician t = await _context.Technicians.Include(r => r.WorkersWithRole)
            .ThenInclude(r => r.RoleWorker).FirstOrDefaultAsync(m => m.Email == UserEmail);
            if (t != null)
            {
                ApplicationUser = t;
            }

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
