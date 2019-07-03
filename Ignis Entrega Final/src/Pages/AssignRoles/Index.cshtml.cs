using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Models;
using Ignis.Models.RoleWorkerViewModel;
using Ignis.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;


namespace Ignis.Pages.AssignRoles
{
    //[Authorize(Roles="Tecnico")]
    public class IndexModel : PageModel
    {

        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }
       
        public string CurrentFilter { get; set; }

        public int WorkerRoleID { get; set; }
        public string TecnicoID { get; set; }
        public RoleWorkerIndexData tecnico { get; set; }
        public Admin Admin { get; set; }


        public async Task OnGetAsync(string id, int? courseID, string searchString)
        {
            
            IQueryable<Technician> studentIQ = from c in _context.Technicians
                                    select c;
             if (!String.IsNullOrEmpty(searchString))
            {
                studentIQ = studentIQ.Where(c => c.Name.Contains(searchString));
            }
           
            // Decidimos que el IndexModel tenga que administrar la lista de técnicos
            // filtrados (es decir que se fije si el técnico tiene como verdadero el
            // bool Available) para que cuando el Admin entre a esta página, se agreguen
            // los técnicos correspondientes a la lista.

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
            _context.SaveChanges();

            
            tecnico = new RoleWorkerIndexData();
            tecnico.Technicians= await studentIQ
            .Include(i => i.WorkersWithRole)
                .ThenInclude(i=> i.RoleWorker)
                .OrderBy(i=>i.Name)
                .ToListAsync();
            
            
        }
    }
}
