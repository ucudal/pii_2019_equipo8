// using System;
// using System.Collections.Generic;

// //Nuestra clase Admin cumple con el patrón Expert ya que es la experta en información (maneja
// //todos los datos referentes a los usuarios).
// //Admin también cumple con el principio SRP ya que todas sus responsabilidades se basan
// //únicamente en el manejo de la información de los usuarios (no tiene responsabilidades cómo
// //por ejemplo, imprimir los datos de los usuarios).
// namespace AppProyecto.Models
// {
//     public class Admin : User
//     {
//         public List<Worker> Workerlist;
//         public List<User> DisableUsersList;
//         public List<Client> Clientlist;
//         public List<String> Consults = new List<String>();
//         public Admin (string Name, string Mail, string Password, List<Worker> Workerlist)
//         {
//             this.Name = Name;
//             this.Mail = Mail;
//             this.Password = Password;
//             this.Workerlist = Workerlist;
//             this.Disable = false;
//         }
//         public override void AddToAdmin(Admin admin){}
//         public void ActivateUser (User user)
//         {
//             if (this.DisableUsersList.Contains(user))
//             {
//                 user.Disable = false;
//                 this.DisableUsersList.Remove(user);
//                 user.AddToAdmin(this);
//             }
//         }
//         public void DisableUser (User user)
//         {
//             if (!this.DisableUsersList.Contains(user))
//             {
//                 user.Disable = true;
//                 this.DisableUsersList.Add(user);
//             }
//         }
//         public void AddConsults(string consult)
//         {
//             this.Consults.Add(consult);
//         }
//         //Aca aplicamos el patrón Polimorfism ya que SortWorkers recibe por parametro un ISort
//         //y definimos una operación polimórfica donde el receptor del mensaje con selector SortWorker
//         //es un subtipo de ISort (nunca preguntamos por el tipo de Sort).
//         //También aplicamos el principio LSP ya que al sustituir ISort por alguno de sus subtipos no se
//         //encuentran efectos colaterales (un efecto colateral puede ser, por ejemplo, que algún atributo
//         //de Worker se haya cambiado).
//         public List<Worker> SortWorkers(ISort sort)
//         {
//             return sort.SortWorker(this.Workerlist);
//         }  

//     }
// }