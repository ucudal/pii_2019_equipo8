using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
namespace AppProyecto.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesUserContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesUserContext>>()))
            {
				
			
                // Look for any movies.
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }
                // List<Role> roles = new List<Role>();
                //     roles.Add(new Role("Sonidista"));
                //     roles.Add(new Role("Fotografo"));
                //     List<Role> roles1 = new List<Role>();
                //     roles1.Add(new Role("Diseñador"));
                context.User.AddRange(


                    new Client
                    {
                        Type = "Client",
                        Name = "Julio Ribas",
                        Mail = "prueba@gmail.com",
                        Disable = true,
                        Password = "contraseña"
                    },

                    new Client
                    {
                        Type = "Client",
                        Name = "Julio Cesar Antunez",
                        Mail = "prueba1@gmail.com",
                        Disable = true,
                        Password = "contraseña"
                    },

                    new Worker
                    {
                        Type = "Worker",
                        Name = "Mario Saralegui",
                        Mail = "prueba2@gmail.com",
                        Password = "contraseña",
                        Disable = true,
                        //  RoleList = roles,
                        Available = true,
                        WorkedHours = 0,
                        TotalWorks = 0,
                    },

                    new Worker
                    {
                        Type = "Worker",
                        Name = "Rosario Martinez",
                        Mail = "prueba3@gmail.com",
                        Password = "contraseña",
                        Disable = true,
                        // RoleList = roles1,
                        Available = true,
                        WorkedHours = 0,
                        TotalWorks = 0,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}