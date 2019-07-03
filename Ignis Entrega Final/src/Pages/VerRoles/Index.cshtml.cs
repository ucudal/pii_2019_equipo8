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
    public class IndexModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public PaginatedList<RoleWorker> RoleWorker { get; set; }

         public string TitleSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<RoleWorker> rolesIQ = from s in _context.RoleWorker
                                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                rolesIQ = rolesIQ.Where(s => s.Title.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "title_desc":
                    rolesIQ = rolesIQ.OrderByDescending(s => s.Title);
                    break;
                default:
                    rolesIQ = rolesIQ.OrderBy(s => s.Title);
                    break;
            }

            int pageSize = 5;
            RoleWorker = await PaginatedList<RoleWorker>.CreateAsync(
                rolesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

        }
    }
}
