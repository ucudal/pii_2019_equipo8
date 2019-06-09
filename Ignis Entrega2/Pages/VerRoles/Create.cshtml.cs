using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ignis.Models;

namespace Ignis.Pages.VerRoles
{
    public class CreateModel : PageModel
    {
        private readonly Ignis.Models.IgnisContext _context;

        public CreateModel(Ignis.Models.IgnisContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RoleWorker RoleWorker { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RoleWorker.Add(RoleWorker);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}