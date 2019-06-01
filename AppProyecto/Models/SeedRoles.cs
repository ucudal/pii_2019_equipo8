using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
namespace AppProyecto.Models
{
    public static class SeedRole
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesUserContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesUserContext>>()))
            {
				
			
                // Look for any movies.
                if (context.Role.Any())
                {
                    return;   // DB has been seeded
                }
                // List<Role> roles = new List<Role>();
                //     roles.Add(new Role("Sonidista"));
                //     roles.Add(new Role("Fotografo"));
                //     List<Role> roles1 = new List<Role>();
                //     roles1.Add(new Role("Diseñador"));
                context.Role.AddRange(


                    new Role
                    {
                        Name = "Fotografo",
                    },

                    new Role
                    {
                        Name = "Sonidista",
                    },

                    new Role
                    {
                        Name = "Diesñador",
                    },

                    new Role
                    {
                        Name = "Camarografo",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}