using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ignis.Models
{
    public class ContractByHour : Contract
    {
        public override int BaseCost { get; set; } = 380;
        [Display(Name = "Hours")]
        public override int Time { get; set; }
    }
}