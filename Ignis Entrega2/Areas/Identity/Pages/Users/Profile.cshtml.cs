using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace Ignis.Areas.Identity.Pages.Users
{
    [Authorize(Roles=IdentityData.AdminRoleName)] // Solo los usuarios con rol administrador pueden acceder a este controlador
    public class ProfileModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;
        public ProfileModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }
        public List<String> Properties {get; set;}

        public ApplicationUser ApplicationUser{get;set;}

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ApplicationUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            
            
            Properties = ApplicationUser.ShowProperties();

            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
