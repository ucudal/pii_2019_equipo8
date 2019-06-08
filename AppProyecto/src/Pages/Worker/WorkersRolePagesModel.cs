using RazorPagesMovie.Models;
using RazorPagesMovie.Models.PageViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesMovie.Pages.VerWorkers
{
    public class WorkersRolesPageModel : PageModel
    {

        public List<AssignedRoleData> AssignedRoleDataList;

        public void PopulateAssignedRoleData(RazorPagesMovieContext context, 
                                               RazorPagesMovie.Areas.Identity.Data.Tecnico worker)
        {
            var allRoles = context.Roles;
            //var workerRoles = new HashSet<int>(
                //worker.RoleAssignments.Select(c => c.RoleID));
            AssignedRoleDataList = new List<AssignedRoleData>();
            foreach (var role in allRoles)
            {
                AssignedRoleDataList.Add(new AssignedRoleData
                {
                    RoleID = role.ID,
                    Name = role.Name,
                    //Assigned = workerRoles.Contains(role.ID)
                });
            }
        }

        public void UpdateWorkerRoles(RazorPagesMovieContext context, 
            string[] selectedRoles, RazorPagesMovie.Areas.Identity.Data.Tecnico workerToUpdate)
        {
            // if (selectedRoles == null)
            // {
            //     workerToUpdate.RoleAssignments = new List<RoleAssignment>();
            //     return;
            // }

            var selectedRolesHS = new HashSet<string>(selectedRoles);
            //var workerRoles = new HashSet<int>
            //    (workerToUpdate.RoleAssignments.Select(c => c.WorkerRole.ID));
            foreach (var role in context.Roles)
            {
                if (selectedRolesHS.Contains(role.ID.ToString()))
                {
             //       if (!workerRoles.Contains(role.ID))
            //        {
                        // workerToUpdate.RoleAssignments.Add(
                            // new RoleAssignment
                            // {
                            //     WorkerID = workerToUpdate.Id,
                            //     RoleID = role.ID
                            // });
            //        }
                }
                else
                {
            //        if (workerRoles.Contains(role.ID))
              //      {
                        // RoleAssignment roleToRemove
                        //     = workerToUpdate
                        //         .RoleAssignments
                        //         .SingleOrDefault(i => i.RoleID == role.ID);
                        // context.Remove(roleToRemove);
                //    }
                }
            }
        }
    }
}