using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ignis.Models
{
    public class Feedback
    {
        public int ID { get; set; }
        [Required]
        public string Comment { get; set; }
        [Range(1,10)]
        public int Rating { get; set; }
    }
}