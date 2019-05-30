using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppProyecto.Models;

namespace AppProyecto.Pages.Role
{
    public class IndexModel : PageModel
    {
        private readonly AppProyecto.Models.RazorPagesRoleContext _context;

        public IndexModel(AppProyecto.Models.RazorPagesRoleContext context)
        {
            _context = context;
        }

        public IList<AppProyecto.Models.Role> Role { get;set; }

        public async Task OnGetAsync()
        {
            Role = await _context.Role.ToListAsync();
        }
    }
}
