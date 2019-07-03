using Ignis;
using Ignis.Models.RoleWorkerViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Ignis.Models;

namespace Ignis.Pages.AssignRoles
{
    public class TecnicoWorkerRolePageModel : PageModel
    {

        public List<AssignedRoleData> AssignedRoleDataList;

        public void PopulateAssignedCourseData(Ignis.Areas.Identity.Data.IdentityContext context, 
                                               Technician tecnico)
        {
            var allRoles = context.RoleWorker;
            var tecnicoRoles = new HashSet<int>(
                tecnico.WorkersWithRole.Select(c => c.RoleWorkerID));
            AssignedRoleDataList = new List<AssignedRoleData>();
            foreach (var role in allRoles)
            {
                AssignedRoleDataList.Add(new AssignedRoleData
                {
                    RoleWorkerID = role.ID,
                    Title = role.Title,
                    
                    Assigned = tecnicoRoles.Contains(role.ID)
                });
            }
        }

        // Este método sirve para cambiar el rol de los técnicos
        public void UpdateInstructorCourses(Ignis.Areas.Identity.Data.IdentityContext context, 
            string[] selectedRoleWorkers, Technician technicianToUpdate)
        {
            if (selectedRoleWorkers == null)
            {
                technicianToUpdate.WorkersWithRole = new List<WorkersWithRole>();
                return;
            }

            var selectedRoleWorkersHS = new HashSet<string>(selectedRoleWorkers);
            var technicianRoles = new HashSet<int>
                (technicianToUpdate.WorkersWithRole.Select(c => c.RoleWorker.ID));
            foreach (var role in context.RoleWorker)
            {
                // Si el rol seleccionado no esta en lista del técnico, se agrega.
                // Si el rol no esta seleccionado pero se encuentra en la lista del técnico,
                // se quita.
                if (selectedRoleWorkersHS.Contains(role.ID .ToString()))
                {
                    if (!technicianRoles.Contains(role.ID))
                    {
                        technicianToUpdate.WorkersWithRole.Add(
                            new WorkersWithRole
                            {
                               TechnicianID = technicianToUpdate.Id,
                               RoleWorkerID = role.ID
                            });
                    }
                }
                else
                {
                    if (technicianRoles.Contains(role.ID))
                    {
                        Models.WorkersWithRole roleToRemove
                            = technicianToUpdate
                                .WorkersWithRole
                                .SingleOrDefault(i => i.RoleWorkerID == role.ID);
                        context.Remove(roleToRemove);
                    }
                }
            }
        }
    }
}