using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
 
    }
}