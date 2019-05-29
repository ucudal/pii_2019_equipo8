using System;

namespace AppProyecto.Models
{
    public class User
    {
        public int ID {get; set;}
        public string Type {get; set;}
        public string Name{get; set;}
        public string Mail{get; set;}
        public string Password{get; set;}
        public bool Disable {get; set;}
        public virtual void AddToAdmin(Admin admin){}
    }
}