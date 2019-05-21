using System;

namespace AppProyecto.Models
{
    public class Client : User
    {
        public int Projects;
        public Client (string Name, string Mail, string Password) 
        : base (Name, Mail, Password)
        {
            
        }
        public string Consult(string consult)
        {
            return consult;
        }
    }
}