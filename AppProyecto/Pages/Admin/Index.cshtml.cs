using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppProyecto.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppProyecto.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly AppProyecto.Models.RazorPagesUserContext _context;

        public IndexModel(AppProyecto.Models.RazorPagesUserContext context)
        {
            _context = context;
        }

        public new IList<User> User { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Type { get; set; }
        [BindProperty(SupportsGet = true)]
        public string UserType { get; set; }
        public async Task OnGetAsync()
        {
                // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from u in _context.User
                                            orderby u.Type
                                            select u.Type;

            var users = from u in _context.User
                        select u;

            if (!string.IsNullOrEmpty(SearchString))
            {
                users = users.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(UserType))
            {
                users = users.Where(x => x.Type == UserType);
            }
            Type = new SelectList(await genreQuery.Distinct().ToListAsync());
            User = await users.ToListAsync();

        

        }
    }
}
