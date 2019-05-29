using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppProyecto.Models;

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

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
