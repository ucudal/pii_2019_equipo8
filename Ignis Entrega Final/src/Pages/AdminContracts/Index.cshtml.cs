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
        private readonly IdentityContext _context;

        public IndexModel(IdentityContext context)
        {
            _context = context;
        }
        public string CurrentFilter { get; set; }
        public IList<Contract> Contract { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            IQueryable<Contract> contractIQ = from c in _context.Contract
                                    select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                contractIQ = contractIQ.Where(c => c.Technician.Name.Contains(searchString)
                               || c.Client.Name.Contains(searchString));
            }
            Contract = await contractIQ.Include(c => c.Technician)
            .Include(c => c.Client).ToListAsync();
        }
    }
}
