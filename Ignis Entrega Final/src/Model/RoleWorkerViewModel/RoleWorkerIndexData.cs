using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ignis.Models.RoleWorkerViewModel
{
    public class RoleWorkerIndexData
    {
    public IEnumerable<RoleWorker> RoleWorkers { get; set; }

        public IEnumerable<Tecnico> Tecnicos { get; set; }

    }
}