using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ignis.Models
{
    public class ContractByDay : Contract
    {
        public override int BaseCost { get; set; } = 1200;
        [Display(Name = "Days")]
        public override int Time { get; set; }
    }
}