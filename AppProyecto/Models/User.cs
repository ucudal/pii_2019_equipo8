using System;

namespace AppProyecto.Models
{
    public abstract class User
    {
        public string Name;
        public string Mail;
        protected string Password;
        public bool Disable = true;
        public User (string Name, string Mail, string Password)
        {
            this.Name = Name;
            this.Mail = Mail;
            this.Password = Password;
        }
        public abstract void AddToAdmin(Admin admin);
    }
}