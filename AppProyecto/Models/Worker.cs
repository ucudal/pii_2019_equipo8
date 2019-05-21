using System;
using System.Collections.Generic;

namespace AppProyecto.Models
{
    public class Worker : User
    {
        public List<Role> Rolelist;
        public int AverageRanking;
        public bool Available;
        public int WorkedHours;
        public int TotalWorks;
        public Worker (string Name, string Mail, string Password, List<Role> Rolelist) 
        : base (Name, Mail, Password)
        {
            this.Name = Name;
            this.Mail = Mail;
            this.Password = Password;
            this.Rolelist = Rolelist;
        } 
    }
}