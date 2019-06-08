using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RazorPagesMovie.Models
{
    public enum Level
    {
        Avanzado, Basico
    }
    public class WorkerRole
    {
        public int ID{get;set;}
        public string Name{get;set;}
         [DisplayFormat(NullDisplayText = "No level")]
        public Level? Level { get; set; }

        //public ICollection<RoleAssignment> RoleAssignments { get; set; }


    }
}