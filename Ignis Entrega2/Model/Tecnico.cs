using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Ignis.Areas.Identity.Data
{
    public class Tecnico : Ignis.Areas.Identity.Data.ApplicationUser
    {
        public int AverageRanking{get;set;}
        public bool Available{get; set;}
        public int WorkedHours{get; set;}
        public int TotalWorks{get; set;}
        //public List<Ignis.Models.WorkersWithRole> WorkersWithRoles { get; set; }

        //public ICollection<Ignis.Models.WorkerRoleAssignment> WorkerRoleAssignments { get; set; }
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
        // public override void AddToAdmin(Admin admin)
        // {
        //     admin.Workerlist.Add(this);
        // }
        
 
    }
}