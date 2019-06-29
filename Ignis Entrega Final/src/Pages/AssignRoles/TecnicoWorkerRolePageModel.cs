using Ignis;
using Ignis.Models.RoleWorkerViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Ignis.Models;

namespace Ignis.Pages.AssignRoles
{
    public class TechnicianWorkerRolePageModel : PageModel
    {

        public List<AssignedRoleData> AssignedRoleDataList;

        public void PopulateAssignedCourseData(Ignis.Areas.Identity.Data.IdentityContext context, 
                                               Technician Technician)
        {
            var allRoles = context.RoleWorker;
            var TechnicianRoles = new HashSet<int>(
                Technician.RoleWorker.Select(c => c.ID));
            AssignedRoleDataList = new List<AssignedRoleData>();
            foreach (var course in allRoles)
            {
                AssignedRoleDataList.Add(new AssignedRoleData
                {
                    RoleWorkerID = course.ID,
                    Title = course.Title,
                    
                    Assigned = TechnicianRoles.Contains(course.ID)
                });
            }
        }

        public void UpdateInstructorCourses(Ignis.Areas.Identity.Data.IdentityContext context, 
            string[] selectedCourses, Technician instructorToUpdate)
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