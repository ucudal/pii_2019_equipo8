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
            foreach (var course in allRoles)
            {
                AssignedRoleDataList.Add(new AssignedRoleData
                {
                    RoleWorkerID = course.ID,
                    Title = course.Title,
                    
                    Assigned = tecnicoRoles.Contains(course.ID)
                });
            }
        }

        public void UpdateInstructorCourses(Ignis.Areas.Identity.Data.IdentityContext context, 
            string[] selectedCourses, Technician instructorToUpdate)
        {
            if (selectedCourses == null)
            {
                instructorToUpdate.WorkersWithRole = new List<WorkersWithRole>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>
                (instructorToUpdate.WorkersWithRole.Select(c => c.RoleWorker.ID));
            foreach (var course in context.RoleWorker)
            {
                if (selectedCoursesHS.Contains(course.ID .ToString()))
                {
                    if (!instructorCourses.Contains(course.ID))
                    {
                        instructorToUpdate.WorkersWithRole.Add(
                            new WorkersWithRole
                            {
                               TechnicianID = instructorToUpdate.Id,
                               RoleWorkerID = course.ID
                            });
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.ID))
                    {
                        Models.WorkersWithRole courseToRemove
                            = instructorToUpdate
                                .WorkersWithRole
                                .SingleOrDefault(i => i.RoleWorkerID == course.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}