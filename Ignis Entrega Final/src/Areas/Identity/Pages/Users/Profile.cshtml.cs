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
//cosas dependiendo de si el usuario es Client o Technician. Por lo tanto, aquí hace sentido el uso de
//la herencia en Client y Technician como ancestros de ApplicationUser, ya que pudimos aplicar uno de los
//patrones GRASP el cual es Polimorfism. Como ApplicationUser tiene una definición para ShowProperties
//y NamesOfProperties, definimos dichas operaciones en Client y Technician, y aca definimos la operación
//polimórfica donde el receptor del mensaje puede ser de tipo Client o Technician.
//(Esto también cumple con el principio OCP el cual ya se explicó en la clase ApplicationUser).
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
        public List<String> Properties {get; set;}
        public List<String> NamesOfProperties {get; set;}
        public Ignis.Models.RoleWorkerViewModel.RoleWorkerIndexData Technician { get; set; }
        public ApplicationUser ApplicationUser { get;set; }

        public async Task<IActionResult> OnGetAsync(string id,int? courseID)
        {
            if (id == null)
            {
                return NotFound();
            }
            ApplicationUser = await _context.Users.Include(m => m.Contracts).FirstOrDefaultAsync(m => m.Id == id);
            Technician t = await _context.Technicians.Include(r => r.RoleWorker)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (t != null)
            {
                ApplicationUser = t;
            }
            
            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
