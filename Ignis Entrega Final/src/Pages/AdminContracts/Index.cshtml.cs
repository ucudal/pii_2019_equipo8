using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Areas.Identity.Data;
using Ignis.Models;

namespace Ignis.Pages_AdminContracts
{
    public class IndexModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }
public string CurrentFilter { get; set; }
        public IList<Contract> Contract { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            IQueryable<Contract> studentIQ = from c in _context.Contract
                                    select c;
             if (!String.IsNullOrEmpty(searchString))
    {
        studentIQ = studentIQ.Where(c => c.Technician.Name.Contains(searchString)
                               || c.Client.Name.Contains(searchString));
    }
    Contract = await studentIQ
                .Include(c => c.Technician).Include(c => c.Client).ToListAsync();
        }
    }
}
