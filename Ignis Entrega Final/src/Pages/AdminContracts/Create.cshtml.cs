using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ignis.Areas.Identity.Data;
using Ignis.Models;

namespace Ignis.Pages_AdminContracts
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
        ViewData["Tecnico"] = new SelectList(_context.Tecnicos, "Id", "Name");
        ViewData["Client"] = new SelectList(_context.Clients, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Contract Contract { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            Contract contract = _context.Contract.Find(Contract.ClientId, Contract.TecnicoId);
            if (contract != null)
            {
                return Page();
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