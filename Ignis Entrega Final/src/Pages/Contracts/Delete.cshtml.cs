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

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contract = await _context.Contract.Include(m => m.Tecnico).Include(m => m.Client)
            .FirstOrDefaultAsync(m => m.ClientId == id);

            if (Contract == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null)
            {
                return NotFound();
            }

            Contract = await _context.Contract.Include(m => m.Tecnico)
            .FirstOrDefaultAsync(m => m.ClientId == id);
            
            Contract.Tecnico.TotalWorks = Contract.Tecnico.TotalWorks + 1;
            Contract.Tecnico.TotalPoints = Contract.Tecnico.TotalPoints + Feedback.Rating;

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