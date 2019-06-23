using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Ignis.Models
{
     public enum Level
    {
        Avanzado, Basico
    }
    public class RoleWorker
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        public Level? Level { get; set; }
    }
}