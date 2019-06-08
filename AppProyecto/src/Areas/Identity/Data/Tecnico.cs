using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace RazorPagesMovie.Areas.Identity.Data
{
    public class Tecnico : RazorPagesMovie.Areas.Identity.Data.ApplicationUser
    {
        public int AverageRanking{get;set;}
        public bool Available{get; set;}
        public int WorkedHours{get; set;}
        public int TotalWorks{get; set;}
        public int? RoleID { get; set; }
        public override List<String> ShowProperties()
        {
            List<String> result = new List<String>();
             
        result.Add(this.Name.ToString());
        result.Add(this.AverageRanking.ToString());
        result.Add(this.Available.ToString());
        result.Add(this.WorkedHours.ToString());
        result.Add(this.TotalWorks.ToString());
        return result;
        }
        public override List<String> NameOfProperties()
        {
            List<String> result = new List<String>();
             
        result.Add("Name");
        result.Add("AverageRanking");
        result.Add("AValiable");
        result.Add("WorkedHours");
        result.Add("TotalWorks");
        return result;
        }
        
 
    }
}