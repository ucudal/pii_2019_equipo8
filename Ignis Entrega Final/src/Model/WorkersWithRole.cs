using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Ignis.Areas.Identity.Data;

namespace Ignis.Models
{
    public class WorkersWithRole
    {
        
        public string TechnicianID { get; set; }

        
        public int RoleWorkerID { get; set; }

        [Required]
        public Technician Technician { get; set; }

        [Required]
        public RoleWorker RoleWorker { get; set; }
    }
}