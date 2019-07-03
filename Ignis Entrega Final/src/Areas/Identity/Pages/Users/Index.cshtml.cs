using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

// Las páginas y controladores con nombres Index, Create, Edit y Delete son creadas con el Scaffolding
// del ASP.NET. Es decir, la mayoría del código no está creado por nosotros. Estas páginas solo las puede
// ver el administrador
namespace Ignis.Areas.Identity.Pages.Users
{
    [Authorize(Roles=IdentityData.AdminRoleName)] // Solo los usuarios con rol administrador pueden acceder a este controlador
    public class IndexModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }
        // A esta página decidimos agregarle estas propiedades para que se puedan ordenar
        // los usuarios y facilitar la búsqueda
        [BindProperty(SupportsGet = true)]
        public string NameSort { get; set; }
        public string RoleSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<ApplicationUser> ApplicationUser { get; set; }


        public SelectList Names { get; set; }

        public async Task OnGetAsync(string sortOrder,
    string currentFilter, string searchString, int? pageIndex)
        {
            
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            RoleSort = sortOrder == "Role" ? "role_desc" : "Role";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

             IQueryable<ApplicationUser> userIQ = from s in _context.Users
             where s.Role != IdentityData.AdminRoleName
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                userIQ = userIQ.Where(s => s.Name.Contains(searchString)
                                    || s.Email.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    userIQ = userIQ.OrderByDescending(s => s.Name);
                    break;
                case "Role":
                    userIQ = userIQ.OrderBy(s => s.Role );
                    break;
                case "role_desc":
                    userIQ = userIQ.OrderByDescending(s => s.Role);
                    break;
                default:
                    userIQ = userIQ.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 5;
            ApplicationUser = await PaginatedList<ApplicationUser>.CreateAsync(
                userIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            




           
        }
    }
}
