using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

//Tecnico es el usuario que tiene el rol del "técnico" en la aplicación que pidió el Centro Ignis.
//Por lo tanto Client Tecnico ApplicationUser para que sea un usuario como tal y además definimos las metodos
//ShowProperties y NamesOfProperties para poder mostrar las propiedades ya que son distintas a las de Tecnico.
namespace Ignis.Models
{
    public class Tecnico : Ignis.Areas.Identity.Data.ApplicationUser
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
        public IList<RoleWorker> RoleWorker { get; set; } = new List<RoleWorker>();
        [NotMapped]
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
                foreach(RoleWorker r in this.RoleWorker)
                {
                    roles = roles + r.Title + ", ";
                }
                result.Add(new Property { Name = "Roles", Value = roles });
                return result;
            }    
        }
        
 
    }
}