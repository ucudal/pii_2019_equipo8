using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Models;

namespace Ignis.Pages_Contracts
{
    public class DeleteModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public DeleteModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contract Contract { get; set; }
        [BindProperty]
        public Feedback Feedback { get; set; }

        public async Task<IActionResult> OnGetAsync(string id1, string id2)
        {
            if (id1 == null || id2 == null)
            {
                return NotFound();
            }

            Contract = await _context.Contract.Include(m => m.Technician).Include(m => m.Client)
            .FirstOrDefaultAsync(m => (m.ClientId == id1 & m.TechnicianId == id2));

            if (Contract == null)
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


            Contract = await _context.Contract.Include(m => m.Technician)
            .FirstOrDefaultAsync(m => (m.ClientId == Contract.ClientId & m.TechnicianId == Contract.TechnicianId));
            
            Contract.Technician.TotalWorks = Contract.Technician.TotalWorks + 1;
            Contract.Technician.TotalPoints = Contract.Technician.TotalPoints + Feedback.Rating;

            if (Contract != null)
            {
                _context.Contract.Remove(Contract);
                _context.Feedbacks.Add(Feedback);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}