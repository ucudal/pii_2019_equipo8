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
                                               Tecnico tecnico)
        {
            var allRoles = context.RoleWorker;
            var tecnicoRoles = new HashSet<int>(
                tecnico.RoleWorker.Select(c => c.ID));
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
            string[] selectedCourses, Tecnico instructorToUpdate)
        {
            if (selectedCourses == null)
            {
                instructorToUpdate.RoleWorker = new List<RoleWorker>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>
                (instructorToUpdate.RoleWorker.Select(c => c.ID));
            foreach (var course in context.RoleWorker)
            {
                if (selectedCoursesHS.Contains(course.ID .ToString()))
                {
                    if (!instructorCourses.Contains(course.ID))
                    {
                        instructorToUpdate.RoleWorker.Add(course);
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.ID))
                    {
                        instructorToUpdate.RoleWorker.Remove(course);
                    }
                }
            }
        }
    }
}