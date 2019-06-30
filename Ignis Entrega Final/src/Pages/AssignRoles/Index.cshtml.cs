using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ignis.Models;
using Ignis.Models.RoleWorkerViewModel;
using Ignis.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;


namespace Ignis.Pages.AssignRoles
{
    //[Authorize(Roles="Tecnico")]
    public class IndexModel : PageModel
    {

        private readonly Ignis.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(Ignis.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }
        public int WorkerRoleID { get; set; }
        public string TecnicoID { get; set; }
        public RoleWorkerIndexData tecnico { get; set; }




        public List<String> Properties {get; set;}
        public List<String> NamesOfProperties {get; set;}
        public ApplicationUser ApplicationUser{get;set;}


        public async Task OnGetAsync(string id, int? courseID)
        {            
            // //Acá estan las 2 operaciones polimórficas, las cuales cumplen con el principio
            // //LSP ya que al sustituir ApplicationUser por Client o Tecnico no se encuentran efectos
            // //colaterales. Un ejemplo de efecto colateral puede ser que alla una propiedad que valga
            // //null.
            
            tecnico = new RoleWorkerIndexData();
            tecnico.Technicians= await _context.Technicians
            .Include(i => i.WorkersWithRole)
                .ThenInclude(i=> i.RoleWorker)
                .OrderBy(i=>i.Name)
                .ToListAsync();
            
        }
    }
}
