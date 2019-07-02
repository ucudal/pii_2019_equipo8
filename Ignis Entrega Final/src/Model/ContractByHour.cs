using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ignis.Models
{
    //Los contratos que se crean son por jornada o por hora, por lo tanto aquí
    //la property Time cobra el significado de "Hours", es decir jornadas, y el
    //costo base es el del documento del Centro Ignis
    public class ContractByHour : Contract
    {
        public override int BaseCost { get; set; } = 380;
        [Display(Name = "Hours")]
        public override int Time { get; set; }
    }
}