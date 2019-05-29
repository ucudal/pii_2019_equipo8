using System;
using System.Collections.Generic;

namespace AppProyecto.Models
{
    public class Worker : User
    {
        public List<Role> RoleList{get; set;}
        public int AverageRanking;
        public bool Available{get; set;}
        public int WorkedHours{get; set;}
        public int TotalWorks{get; set;}
        public override void AddToAdmin(Admin admin)
        {
            admin.Workerlist.Add(this);
        } 
    }
}