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

        public IList<Technician> Technician { get;set; }
        public Admin Admin { get; set; }

        public async Task OnGetAsync()
        {
            Admin = await _context.Admin.Include(m => m.ListaTechnicians)
            .FirstOrDefaultAsync (m => m.Role == IdentityData.AdminRoleName);
            foreach (Technician t in _context.Technicians)
            {
                if (t.Available == true)
                {
                    if (!Admin.ListaTechnicians.Contains(t))
                    {
                        Admin.ListaTechnicians.Add(t);
                    }
                }
                else
                {
                    if (Admin.ListaTechnicians.Contains(t))
                    {
                        Admin.ListaTechnicians.Remove(t);
                    }
                }
            }
            Technician = await _context.Technicians.Include(m => m.RoleWorker).ToListAsync();
            await _context.SaveChangesAsync();
        }
    }
}
