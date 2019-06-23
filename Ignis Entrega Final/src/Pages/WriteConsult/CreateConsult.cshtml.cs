using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ignis.Models;
using Ignis.Areas.Identity.Data;

namespace Ignis.Pages_WriteConsult
{
    public class CreateModel : PageModel
    {
        private readonly IdentityContext _context;

        public CreateModel(IdentityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Consults Consult { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            string UserEmail = User.Identity.Name;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Admin admin = _context.Admin.FirstOrDefault(m => m.Role == IdentityData.AdminRoleName);
            ApplicationUser user = _context.Users.FirstOrDefault(m => m.Email == UserEmail);
            Consult.UserID = user.Id;
            admin.Consults.Add(Consult);
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}