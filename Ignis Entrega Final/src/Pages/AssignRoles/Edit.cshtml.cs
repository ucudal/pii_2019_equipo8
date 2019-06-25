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
    public class EditModel : TecnicoWorkerRolePageModel
    {

        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public EditModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tecnico Tecnico { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

           Tecnico = await _context.Tecnicos
            .Include(i => i.RoleWorker)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

            if (Tecnico == null)
            {
                return NotFound();
            }
            PopulateAssignedCourseData(_context, Tecnico);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id ,string[] selectedCourses)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var instructorToUpdate = await _context.Tecnicos
                    .Include(i => i.RoleWorker)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Tecnico>(
                instructorToUpdate,
                "Tecnico",
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