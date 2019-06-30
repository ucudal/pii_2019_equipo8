using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

//Technician es el usuario que tiene el rol del "técnico" en la aplicación que pidió el Centro Ignis.
//Por lo tanto Client Technician ApplicationUser para que sea un usuario como tal y además definimos las metodos
//ShowProperties y NamesOfProperties para poder mostrar las propiedades ya que son distintas a las de Technician.
namespace Ignis.Models
{
    public class Technician : Ignis.Areas.Identity.Data.ApplicationUser
    {
        public float AverageRanking 
        { 
            get
            {
                if (this.TotalWorks == 0)
                {
                    return 0;
                }
                else
                {
                    return (float)this.TotalPoints/(float)this.TotalWorks;
                }
            } 
        }
        public bool Available { get; set; }
        public int TotalPoints { get; set; }
        public int TotalWorks { get; set; }
        public IList<WorkersWithRole> WorkersWithRole { get; set; } = new List<WorkersWithRole>();
        public override ICollection<Property> Properties {
            get
            {
                ICollection<Property> result = new List<Property>
                {
                    new Property { Name = "AverageRanking", Value = this.AverageRanking.ToString() },
                    new Property { Name = "Available", Value = this.Available.ToString() },
                    new Property { Name = "TotalPoints", Value = this.TotalPoints.ToString() },
                    new Property { Name = "TotalWorks", Value = this.TotalWorks.ToString() }
                };
                string roles = "";
                foreach(WorkersWithRole r in this.WorkersWithRole)
                {
                    roles = roles + r.RoleWorker.Title + ", ";
                }
                result.Add(new Property { Name = "Roles", Value = roles });
                return result;
            }    
        }
        
 
    }
}