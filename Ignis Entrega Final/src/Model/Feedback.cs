using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ignis.Models
{
    // Esta es la clase Feedback la cual cumple el rol del "feedback" cuando
    // el cliente termina su contrato con el tecnico.
    // Hicimos que esta clase sea del tipo IBaseFeedback para poder aplicar DIP
    // en Technician.
    public class Feedback : IBaseFeedback
    {
        public int ID { get; set; }
        [Required]
        public string Comment { get; set; }
        [Range(1,10)]
        public int Rating { get; set; }
    }
}