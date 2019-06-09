using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Areas.Identity.Data;
using RazorPagesMovie.Models;
using RazorPagesMovie.Models.PageViewModels;

namespace RazorPagesMovie.Pages.Worker
{
    public class IndexModel : PageModel
    {
        public int RoleID {get;set;}

        private readonly RazorPagesMovie.Areas.Identity.Data.IdentityContext _context;

        public IndexModel(RazorPagesMovie.Areas.Identity.Data.IdentityContext context)
        {
            _context = context;
        }

         public WorkerIndexData Tecnico { get; set; }
                 public int TecnicoID { get; set; }


        public async Task OnGetAsync()
        {
            Tecnico = new WorkerIndexData();
            Tecnico.Tecnicos = await _context.Tecnico
           // .Include(i => i.RoleAssignments)
            //.Include(i=> i.WorkerRole)
            .OrderBy(i=>i.Name)
            .ToListAsync();
        }
    }
}
