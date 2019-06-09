using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMovieContext>>()))
            {
                // Look for any movies.
                if (context.Roles.Any())
                {
                    return;   
                };
               var roles = new WorkerRole[]
                {
                    new WorkerRole
                    {
                        Name = "Fotografo",
                        Level = Level.Avanzado

                    },
                     new WorkerRole
                    {
                        Name = "Sonidista",
                        Level = Level.Avanzado
                    },

                    new WorkerRole
                    {
                        Name = "Diseñador",
                        Level = Level.Avanzado
                    },

                    new WorkerRole
                    {
                        Name = "Camarografo",
                        Level = Level.Basico
                    }
                };
                foreach (WorkerRole r in roles)
            {
                context.Roles.Add(r);
            }
                context.SaveChanges();
            // var roleWorkers = new RoleAssignment[]
            // {
            //     new RoleAssignment {
            //         RoleID = roles.Single(r => r.Name == "Fotografo" ).ID,                    },
            //     new RoleAssignment {
            //         RoleID = roles.Single(c => c.Name == "Fotografo" ).ID,                    },
            //         new RoleAssignment {
            //         RoleID = roles.Single(c => c.Name == "Sonidista" ).ID,                    },
            // };

            // foreach (RoleAssignment ci in roleWorkers)
            // {
            //     context.RoleAssignments.Add(ci);
            // }
            // context.SaveChanges();
             }
        }
    }
}