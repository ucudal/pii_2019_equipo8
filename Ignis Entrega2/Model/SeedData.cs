using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Ignis.Models
{
    public static class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new IgnisContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<IgnisContext>>()))
            {
              
                SeedRoleWorker(context);
            }
        }

        private static void SeedRoleWorker(IgnisContext context)
        {
            if (context.RoleWorker.Any())
            {
                return;   // DB has been seeded
            }

            context.RoleWorker.AddRange(
                new RoleWorker
                {
                    Title = "Camarografo",
                    Level = Level.Basico
                },

                new RoleWorker
                {
                    Title = "Grabacion",
                    Level = Level.Avanzado
                },

                new RoleWorker
                {
                    Title = "Sonidista",
                    Level = Level.Basico
                },
                new RoleWorker
                {
                   Title = "Fotografo",
                   Level = Level.Avanzado
                }
            );
            context.SaveChanges();
        }
    }
}