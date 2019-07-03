using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ignis.Models
{
    // Los contratos que se crean son por jornada o por hora, por lo tanto aquí
    // la property Time cobra el significado de "Days", es decir jornadas, y el
    // costo base es el del documento del Centro Ignis.

    // Aquí nuevamente usamos herencia para que en los controladores podamos
    // sustituír Contract por sus subtipos
    public class ContractByDay : Contract
    {
        public override int BaseCost { get; set; } = 1200;
        [Display(Name = "Days")]
        public override int Time { get; set; }
    }
}