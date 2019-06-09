using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ignis.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Ignis.Areas.Identity.Data;

//Aquí es donde se corre el programa de nuestra aplicación. En todas nuestras clases del modelo, las vistas
//y los controladores aplicamos el principio SRP el cual dice que ninguna clase debe tener más de una sola
//razón de cambio. Cumplimos con ese principio porque en el modelo tanto ApplicationUser como Tecnico o Client
//solo tienen que mostrar sus propiedades. Lo mismo con los controladores ya que sus responsabilidades
//se basan en encontrar en la base de datos los ApplicationUser y guardar instancias de ellos.
namespace Ignis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context=services.
                        GetRequiredService<IgnisContext>();
                    context.Database.Migrate();
                    SeedData.Initialize(services);
                    SeedIdentityData.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}