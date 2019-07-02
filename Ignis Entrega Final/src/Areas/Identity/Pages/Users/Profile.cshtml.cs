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

//Esta página y controlador llamada Profile fue creada por nosotros mismos; sirve para ver las
//características específicas de los usuarios, por lo tanto aquí se tienen que mostrar diferentes
//cosas dependiendo de si el usuario es Client o Technician. Technician se puede diferenciar de 
//Client por la propiedad Properties.
namespace Ignis.Areas.Identity.Pages.Users
{
    [Authorize(Roles=IdentityData.AdminRoleName)] // Solo los usuarios con rol administrador pueden acceder a este controlador
    public class ProfileModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;
        public ProfileModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }
        public Ignis.Models.RoleWorkerViewModel.RoleWorkerIndexData Technician { get; set; }
        public ApplicationUser ApplicationUser { get;set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            try
            {
                Check.Precondition(id != null, "La pagina no se encontro");
            }
            catch (Check.PreconditionException ex)
            {
                return Redirect("https://localhost:5001/Exception/Exception?id=" + ex.Message);
            }
            ApplicationUser = await _context.Users.Include(m => m.Contracts).FirstOrDefaultAsync(m => m.Id == id);
            Technician t = await _context.Technicians.Include(r => r.WorkersWithRole).ThenInclude(r => r.RoleWorker)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (t != null)
            {
                ApplicationUser = t;
            }
            
            try
            {
                Check.Precondition(ApplicationUser != null, "La pagina no se encontro");
            }
            catch (Check.PreconditionException ex)
            {
                return Redirect("https://localhost:5001/Exception/Exception?id=" + ex.Message);
            }
            return Page();
        }
    }
}
