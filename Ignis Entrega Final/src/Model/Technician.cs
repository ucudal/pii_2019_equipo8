using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Ignis.Areas.Identity.Data;

// Technician es el usuario que tiene el rol del "técnico" en la aplicación que pidió el Centro Ignis.
// Por lo tanto Technician hereda de ApplicationUser para que  sea un usuario como tal 
// y además definimos la propiedad Properties la cual muestra las propiedades específicas del
// tecnico.

// Decidimos usar herencia porque en los controladores podemos sustituir a ApplicationUser
// por Client o Technician. Por lo tanto cumplimos con el principio LSP porque al sustituirlos
// no se encuentre efectos colaterales.
namespace Ignis.Models
{
    public class Technician : ApplicationUser
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
        [Display(Name = "Roles")]
        public IList<WorkersWithRole> WorkersWithRole { get; set; } = new List<WorkersWithRole>();
        public override ICollection<Property> Properties {
            get
            {
                ICollection<Property> result = new List<Property>
                {
                    new Property { Name =  "Name", Value = this.Name },
                    new Property { Name = "AverageRanking", Value = this.AverageRanking.ToString()},
                    new Property { Name = "TotalWorks", Value = this.TotalWorks.ToString()},
                    new Property { Name = "Available", Value = this.Available.ToString() }
                    
                };
                string roles = "";
                foreach(WorkersWithRole r in this.WorkersWithRole)
                {
                    roles = roles + r.RoleWorker.Title +" " + r.RoleWorker.Level + ", ";
                }
                result.Add(new Property { Name = "Roles", Value = roles });
                return result;
            }    
        }
        // Aquí aplicamos el principio Dependency Inversion por que Technician ya
        // no depende de Feedback sino que depende de una abstracción.
        public void CalculateRanking(IBaseFeedback feedback)
        {
            // El Feedback no puede valer null
            Check.Precondition(feedback != null, "El Feedback no se escribio");
            this.TotalWorks++;
            this.TotalPoints += feedback.Rating;
        }
        
 
    }
}