using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace RazorPagesMovie.Areas.Identity.Pages.Users
{
    [Authorize(Roles=IdentityData.AdminRoleName)] // Solo los usuarios con rol administrador pueden acceder a este controlador
    public class ProfileModel : PageModel
    {
        private readonly RazorPagesMovie.Areas.Identity.Data.IdentityContext _context;

        public ProfileModel(RazorPagesMovie.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }
        public List<String> Properties {get; set;}

        public List<String> NameOfProperties {get; set;}

        public ApplicationUser ApplicationUser { get;set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            
            Properties = ApplicationUser.ShowProperties();
            NameOfProperties = ApplicationUser.NameOfProperties();

            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
