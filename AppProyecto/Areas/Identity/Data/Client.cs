using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace RazorPagesMovie.Areas.Identity.Data
{
    public class Client : RazorPagesMovie.Areas.Identity.Data.ApplicationUser
    {
        
        public int Projects{get;set;}
        
        public override List<String> ShowProperties()
        {
            List<String> result = new List<String>();
            result.Add(this.Name.ToString());
            result.Add(this.Projects.ToString());
            return result;
        }
        public override List<String> NameOfProperties()
        {
            List<String> result = new List<String>();
            result.Add("Name");
            result.Add("Projects");
            return result;
        }
 
    }
}