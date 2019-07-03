using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Models;
using Ignis.Areas.Identity.Data;

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

        public async Task<IActionResult> OnGetAsync(string idClient, string idTechnician)
        {
            // Como Contract tiene 2 primary key, se debe verificar que los id's que se pasan
            // por parametro no sean nulos. En caso de no serlo, se le manda un mensaje al
            // contexto para que recupere el contrato de la base de datos.

            try
            {
                Check.Precondition(idClient != null & idTechnician != null,
                "La pagina no se encontro");
            }
            catch (Check.PreconditionException ex)
            {
                return Redirect("https://localhost:5001/Exception/Exception?id=" + ex.Message);
            }

            Contract = await _context.Contract.Include(m => m.Technician).Include(m => m.Client)
            .FirstOrDefaultAsync(m => (m.ClientId == idClient & m.TechnicianId == idTechnician));

            try
            {
                Check.Precondition(Contract != null, "El contrato no se encontro");
            }
            catch (Check.PreconditionException ex)
            {
                return Redirect("https://localhost:5001/Exception/Exception?id=" + ex.Message);
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

            // Para que el AverageRanking del tecnico quede actualizado, le mando un mensaje
            // al tecnico para que recalcule el ranking.
            // Si el controlador tuviera la responsabilidad de cambiar el AverageRanking,
            // se violaría el principio SRP.
            try
            {
                Contract.Technician.CalculateRanking(Feedback);
            }
            catch (Check.PreconditionException ex)
            {
                return Redirect("https://localhost:5001/Exception/Exception?id=" + ex.Message);
            }

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