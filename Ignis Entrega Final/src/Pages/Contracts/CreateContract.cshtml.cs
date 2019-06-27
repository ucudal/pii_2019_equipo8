using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ignis.Areas.Identity.Data;
using Ignis.Models;
using Microsoft.EntityFrameworkCore;

namespace Ignis.Pages_Contracts
{
    public class CreateModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public CreateModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Admin = _context.Admin.Include(m => m.ListaTecnicos).ThenInclude(m => m.RoleWorker)
            .FirstOrDefault(m => m.Role == IdentityData.AdminRoleName);
            ViewData["Tecnico"] = new SelectList(Admin.ListaTecnicos, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Contract Contract { get; set; }
        public Admin Admin { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            string ClientName = User.Identity.Name;
            Client client = _context.Clients.FirstOrDefault(m => m.Email == ClientName);
            Contract.ClientId = client.Id;
            Contract contract = _context.Contract.Find(Contract.ClientId, Contract.TecnicoId);
            if (contract != null)
            {
                return RedirectToPage("./Index");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            Contract.Client = _context.Clients.Find(Contract.ClientId);
            Contract.Tecnico = _context.Tecnicos.Find(Contract.TecnicoId);
            Contract.Client.Contracts.Add(Contract);
            Contract.Tecnico.Contracts.Add(Contract);
            
            _context.Contract.Add(Contract);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}