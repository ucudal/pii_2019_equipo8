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
    //Este es el controlador para crear un contrato por jornada, decidimos
    //hacerlo de esta forma para evitar preguntar con un if por el tipo del contrato
    public class CreateByDayModel : PageModel
    {
        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public CreateByDayModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Esta lista es para elegir al técnico del contrato, donde se puede
            // observar que la lista que se da es la filtrada por el Admin.
            // El valor que se selecciona del tecnico  es el Id, mientras que el valor
            // que se muestra es el nombre.
            Admin = _context.Admin.Include(m => m.ListaTechnicians).ThenInclude(m => m.WorkersWithRole)
            .ThenInclude(m => m.RoleWorker).FirstOrDefault(m => m.Role == IdentityData.AdminRoleName);
            ViewData["Technician"] = new SelectList(Admin.ListaTechnicians, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public ContractByDay Contract { get; set; }
        public Admin Admin { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Busco al Admin en la base de datos
            Admin = _context.Admin.FirstOrDefault(m => m.Role == IdentityData.AdminRoleName);

            // Aqui encuentro al cliente con el Username y le asigno el Id de dicho cliente al
            // contrato
            string clientName = User.Identity.Name;
            Client client = _context.Clients.FirstOrDefault(m => m.Email == clientName);
            try
            {
                Check.Precondition(client != null, "No se encontro el cliente");
            }
            catch (Check.PreconditionException ex)
            {
                return Redirect("https://localhost:5001/Exception/Exception?id=" + ex.Message);
            }

            Contract.ClientId = client.Id;

            // Aca busco si en la base de datos ya hay un contrato con el mismo técnico
            // Si lo hay se lanza la excepción.
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

            // Aqui agrego el contrato a la lista de contratos del cliente y el técnico
            Contract.Client = _context.Clients.Find(Contract.ClientId);

            Contract.Technician = _context.Technicians.Find(Contract.TechnicianId);

            Contract.Client.Contracts.Add(Contract);

            Contract.Technician.Contracts.Add(Contract);

            // Como el técnico ya tiene un contrato lo quito de la lista de técnicos filtrada
            // para que si otro cliente quiere crear un contrato no encuentre al técnico
            Contract.Technician.Available = false;
            Admin.ListaTechnicians.Remove(Contract.Technician);
            
            // Aca aplicamos LSP porque la base de datos guarda instancias de Contract,
            // y en el IndexModel mostramos una lista de Contracts. Por lo tanto al sustituír
            // Contract por ContractByDay o ContractByHour no se encuentran efectos colaterales.
            _context.Contract.Add(Contract);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}