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
    public class CreateByHourModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public CreateByHourModel(Ignis.Areas.Identity.Data.IdentityContext context)
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
        public ContractByHour Contract { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            Contract contract = _context.Contract
            .FirstOrDefault(m => m.TechnicianId == Contract.TechnicianId);
            try
            {
                Check.Precondition(contract == null, "El tecnico ya tiene un contrato");
            }
            catch (Check.PreconditionException ex)
            {
                return Redirect("https://localhost:5001/Exception/Exception?id=" + ex.Message);
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