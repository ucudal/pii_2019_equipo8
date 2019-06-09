using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

//Client es el usuario que tiene el rol del "cliente" en la aplicación que pidió el Centro Ignis.
//Por lo tanto Client hereda ApplicationUser para que sea un usuario como tal y además definimos las metodos
//ShowProperties y NamesOfProperties para poder mostrar las propiedades ya que son distintas a las de Tecnico.
namespace Ignis.Areas.Identity.Data
{
    public class Client : Ignis.Areas.Identity.Data.ApplicationUser
    {
        public int Projects{get;set;}
        
        public override List<String> ShowProperties()
        {
            List<String> result = new List<String>();
            result.Add(this.Name.ToString());
            result.Add(this.Projects.ToString());
            return result;
        }
        public override List<String> NamesOfProperties()
        {
            List<String> result = new List<String>();
            result.Add("Name");
            result.Add("Projects");
            return result;
        }
 
    }
}