using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ignis.Areas.Identity.Data;

// Client es el usuario que tiene el rol del "cliente" en la aplicación que pidió el Centro Ignis.
// Por lo tanto Client hereda ApplicationUser para que sea un usuario como tal y además definimos
// la lista Properties la cual muestra las propiedades de Client.

// Decidimos usar herencia porque en los controladores podemos sustituir a ApplicationUser
// por Client o Technician. Por lo tanto cumplimos con el principio LSP porque al sustituirlos
// no se encuentran efectos colaterales.

namespace Ignis.Models
{
    public class Client : ApplicationUser
    {
        public int Projects 
        { 
            get
            {
                return this.Contracts.Count;
            }
        }
        [NotMapped]
        public override ICollection<Property> Properties 
        { 
            get
            {
                ICollection<Property> result = new List<Property>
                {
                    new Property { Name = "Name", Value = this.Name },
                    new Property { Name = "Projects", Value = this.Projects.ToString() }
                };
                return result;
            } 
        }
    }
}