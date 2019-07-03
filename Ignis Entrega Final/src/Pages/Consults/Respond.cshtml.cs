using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ignis.Areas.Identity.Data;
using Ignis.Models;

namespace Ignis.Pages_Consults
{
    public class RespondModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public RespondModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string IdUser)
        {
            if (IdUser == null)
            {
                return NotFound();
            }

            ApplicationUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == IdUser);

            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ApplicationUser).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(ApplicationUser.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserExists(string IdUser)
        {
            return _context.Users.Any(e => e.Id == IdUser);
        }
    }
}