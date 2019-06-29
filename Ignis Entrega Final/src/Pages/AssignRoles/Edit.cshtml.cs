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
    public class EditModel : TechnicianWorkerRolePageModel
    {

        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public EditModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Technician Technician { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

           Technician = await _context.Technicians
            .Include(i => i.RoleWorker)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

            if (Technician == null)
            {
                return NotFound();
            }
            PopulateAssignedCourseData(_context, Technician);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id ,string[] selectedCourses)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var instructorToUpdate = await _context.Technicians
                    .Include(i => i.RoleWorker)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Technician>(
                instructorToUpdate,
                "Technician",
                i => i.Name,i => i.RoleWorker))
            {
                UpdateInstructorCourses(_context, selectedCourses, instructorToUpdate);
                await _context.SaveChangesAsync();
                
                return RedirectToPage("./Index");
            }
            UpdateInstructorCourses(_context, selectedCourses, instructorToUpdate);
            PopulateAssignedCourseData(_context, instructorToUpdate);
            
            return Page();
           
        }
    }
}
