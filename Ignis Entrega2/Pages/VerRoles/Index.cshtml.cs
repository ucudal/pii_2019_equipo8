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
        private readonly Ignis.Models.IgnisContext _context;

        public IndexModel(Ignis.Models.IgnisContext context)
        {
            _context = context;
        }

        //public IList<RoleWorker> RoleWorker { get;set; }
        public PaginatedList<RoleWorker> RoleWorker { get; set; }

         public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

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

            IQueryable<RoleWorker> studentIQ = from s in _context.RoleWorker
                                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                studentIQ = studentIQ.Where(s => s.Title.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.Title);
                    break;
                default:
                    studentIQ = studentIQ.OrderBy(s => s.Title);
                    break;
            }

            int pageSize = 3;
            RoleWorker = await PaginatedList<RoleWorker>.CreateAsync(
                studentIQ.AsNoTracking(), pageIndex ?? 1, pageSize);


                    //RoleWorker = await _context.RoleWorker.ToListAsync();
        }
    }
}
