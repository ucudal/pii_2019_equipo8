using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ignis.Models;
using Ignis.Models.RoleWorkerViewModel;
using Ignis.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Ignis.Pages.AssignRoles
{
    public class AssignModel : TecnicoWorkerRolePageModel
    {

        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public AssignModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Technician Tecnico { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

           Tecnico = await _context.Technicians
            .Include(i => i.WorkersWithRole).ThenInclude(i => i.RoleWorker)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

            if (Tecnico == null)
            {
                return NotFound();
            }
            PopulateAssignedCourseData(_context, Tecnico);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id ,string[] selectedRoles)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var technicianToUpdate = await _context.Technicians
                .Include(i => i.WorkersWithRole)
                    .ThenInclude(i => i.RoleWorker)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Technician>(
                technicianToUpdate,
                "Tecnico",
                i => i.Name,i => i.WorkersWithRole))
            {
                UpdateInstructorCourses(_context, selectedRoles, technicianToUpdate);
                // Esta excepción esta porque consideramos que si el técnico tiene más de
                // 3 roles sería demasiado
                try
                {
                    Check.Postcondition(technicianToUpdate.WorkersWithRole.Count <= 3,
                    "El tecnico no puede tener mas de 3 roles");
                }
                catch (Check.PostconditionException ex)
                {
                    return Redirect("https://localhost:5001/Exception/Exception?id=" + ex.Message);
                }
                await _context.SaveChangesAsync();
                
                return RedirectToPage("./Index");
            }
            UpdateInstructorCourses(_context, selectedRoles, technicianToUpdate);
            PopulateAssignedCourseData(_context, technicianToUpdate);
            
            return Page();
           
        }
    }
}
