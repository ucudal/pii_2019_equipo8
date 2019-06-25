using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Areas.Identity.Data;
using Ignis.Models;

namespace Ignis.Pages_TechnicianList
{
    public class IndexModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public IList<Tecnico> Tecnico { get;set; }
        public Admin Admin { get; set; }

        public async Task OnGetAsync()
        {
            Admin = await _context.Admin.Include(m => m.ListaTecnicos)
            .FirstOrDefaultAsync (m => m.Role == IdentityData.AdminRoleName);
            foreach (Tecnico t in _context.Tecnicos)
            {
                if (t.Available == true)
                {
                    if (!Admin.ListaTecnicos.Contains(t))
                    {
                        Admin.ListaTecnicos.Add(t);
                    }
                }
                else
                {
                    if (Admin.ListaTecnicos.Contains(t))
                    {
                        Admin.ListaTecnicos.Remove(t);
                    }
                }
            }
            Tecnico = await _context.Tecnicos.Include(m => m.RoleWorker).ToListAsync();
            await _context.SaveChangesAsync();
        }
    }
}
