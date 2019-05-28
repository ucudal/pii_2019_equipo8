using System;
using System.Collections.Generic;

namespace AppProyecto.Models
{
    public class Admin : User
    {
        public List<Worker> Workerlist;
        public List<User> DisableUsersList;
        public List<Client> Clientlist;
        public List<String> Consults = new List<String>();
        public Admin (string Name, string Mail, string Password, List<Worker> Workerlist)
        : base (Name, Mail, Password)
        {
            this.Name = Name;
            this.Mail = Mail;
            this.Password = Password;
            this.Workerlist = Workerlist;
            this.Disable = false;
        }
        public override void AddToAdmin(Admin admin){}
        public void ActivateUser (User user)
        {
            if (this.DisableUsersList.Contains(user))
            {
                user.Disable = false;
                this.DisableUsersList.Remove(user);
                user.AddToAdmin(this);
            }
        }
        public void DisableUser (User user)
        {
            if (!this.DisableUsersList.Contains(user))
            {
                user.Disable = true;
                this.DisableUsersList.Add(user);
            }
        }
        public void AddConsults(string consult)
        {
            this.Consults.Add(consult);
        }
        public List<Worker> SortWorkers(ISort sort)
        {
            return sort.SortWorker(this.Workerlist);
        } 

    }
}