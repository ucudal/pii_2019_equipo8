using System;

namespace AppProyecto.Models
{
    public class User
    {
        public int ID {get; set;}
        public string Name;
        public string Mail;
        public string Password;
        public bool Disable = true;
        public virtual void AddToAdmin(Admin admin){}
    }
}