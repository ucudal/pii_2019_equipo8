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
        [BindProperty(SupportsGet = true)]
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<ApplicationUser> ApplicationUser { get; set; }


        public SelectList Names { get; set; }
        //public IList<ApplicationUser> ApplicationUser { get;set; }

        public async Task OnGetAsync(string sortOrder,
    string currentFilter, string searchString, int? pageIndex)
        {
            
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

             IQueryable<ApplicationUser> studentIQ = from s in _context.Users
             where s.Role != IdentityData.AdminRoleName
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                studentIQ = studentIQ.Where(s => s.Name.Contains(searchString)
                                    || s.Email.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    studentIQ = studentIQ.OrderBy(s => s.Role );
                    break;
                case "date_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.Role);
                    break;
                default:
                    studentIQ = studentIQ.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 3;
            ApplicationUser = await PaginatedList<ApplicationUser>.CreateAsync(
                studentIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            

            //ApplicationUser = await users.ToListAsync();



           
        }
    }
}
