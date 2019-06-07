using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Models.PageViewModels
{
    public class WorkerIndexData
    {
        public IEnumerable<RazorPagesMovie.Areas.Identity.Data.Tecnico> Tecnicos { get; set; }
        public IEnumerable<RazorPagesMovie.Models.WorkerRole> Roles { get; set; }
    }
}