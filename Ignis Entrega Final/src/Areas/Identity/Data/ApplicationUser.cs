using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ignis.Models;
//ApplicationUser es la clase de los usuarios por lo tanto es sucesora de IdentityUser. Aquí aplicamos
//el principio OCP ya que ApplicationUser es nuestra clase abierta a la extensión (Le podemos agregar nuevas 
//responsanilidades por ejemplo ShowProperties o NameOfProperties) y las sucesoras las cuales son
//Client y Tecnico son clases cerradas a la modificación es decir, no modificamos su comportamiento.

namespace Ignis.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public class Property
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
        [Key]
        public override string Id {get;set;}
        [PersonalData]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [PersonalData]
        public DateTime DOB { get; set; }
        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        [NotMapped]
        public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
        public string Response { get; set; }

        // Es necesario tener acceso a IdentityManager para poder buscar el rol de este usuario; esta propiedad se asigna cada vez que se
        // cambia el rol usando IdentityManager para poder buscar por rol después cuando no hay acceso a IdentityManager. La propiedad
        // puede ser null para los usuarios que todavía no tienen un rol asignado.
        public string Role { get; set; }

        // El IdentityManager que se recibe como argumento no se usa en el método; sólo fuera a que el rol del usuario sea cambiado cuando
        // existe en el contexto una instancia válida de IdentityManager.
        public void AssignRole(UserManager<ApplicationUser> identityManager, string role)
        {
            if (identityManager == null)
            {
                throw new ArgumentNullException("identityManager");
            }

            this.Role = role;
        }
    }
}
