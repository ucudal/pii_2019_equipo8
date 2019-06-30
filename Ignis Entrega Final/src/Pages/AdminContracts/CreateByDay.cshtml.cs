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
    public class CreateByDayModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public CreateByDayModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Technician"] = new SelectList(_context.Technicians, "Id", "Name");
        ViewData["Client"] = new SelectList(_context.Clients, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public ContractByDay Contract { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            Contract contract = _context.Contract.Find(Contract.ClientId, Contract.TechnicianId);
            if (contract != null)
            {
                return RedirectToPage("./Index");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            Contract.Client = _context.Clients.Find(Contract.ClientId);
            Contract.Technician = _context.Technicians.Find(Contract.TechnicianId);
            Contract.Client.Contracts.Add(Contract);
            Contract.Technician.Contracts.Add(Contract);
            
            _context.Contract.Add(Contract);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}