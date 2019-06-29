using System;
using System.Collections.Generic;
using Ignis.Models;

namespace Ignis.Areas.Identity.Data
{
    public class Admin : ApplicationUser
    {
        public ICollection<Consults> Consults { get; set; } = new List<Consults>();
        public ICollection<Technician> ListaTechnicians { get; set; } = new List<Technician>();
    }
}