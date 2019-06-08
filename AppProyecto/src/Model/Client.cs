// using System;
// using System.Collections.Generic;
// namespace AppProyecto.Models
// {
//     public class Client : User
//     {
        
//         public int Projects;

//         public ICollection<ContractAssignment> ContractAssignments { get; set; }

//         public override void AddToAdmin(Admin admin)
//         {
//             admin.Clientlist.Add(this);
//         }
//         public void Consult(string consult, Admin admin)
//         {
//             admin.AddConsults(consult);
//         }
//         public void CreateProject(Worker worker)
//         {

//         }
//     }
// }