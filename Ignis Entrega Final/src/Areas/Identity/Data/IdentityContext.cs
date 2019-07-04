using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ignis.Areas.Identity.Data;
using Ignis.Models;

// Este es el contexto el cual hace que se guarden los usuarios en la base de datos.
// Y en los controladores se manda un mensaje a este contexto para que se pueda
// recuperar de la base de datos el objeto que se quiere usar.
namespace Ignis.Areas.Identity.Data
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Technician>().ToTable("Technician");
            builder.Entity<Client>().ToTable("Client");
            builder.Entity<Contract>().HasKey(t => new {t.ClientId, t.TechnicianId});
            builder.Entity<Admin>().ToTable("Admin");
            builder.Entity<Feedback>().ToTable("Feedback");
            builder.Entity<WorkersWithRole>().ToTable("WorkersWithRole");

            builder.Entity<WorkersWithRole>().HasKey(a => new { a.RoleWorkerID, a.TechnicianID});
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
            public DbSet<Technician> Technicians { get; set; }
            public DbSet<Feedback> Feedbacks { get; set; }
            public DbSet<WorkersWithRole> WorkersWithRole { get; set; }
            public DbSet<Admin> Admin { get; set; }
            public DbSet<Client> Clients { get; set; }
            public DbSet<Contract> Contract { get; set; }
            public DbSet<RoleWorker> RoleWorker { get; set; }

        // Definimos estos métodos para poder realizar los tests
        public void Initialize()
        {
            this.GetUsers();
            this.GetRoles();
            this.GetContracts();
            SaveChanges();
        }
        public void GetUsers()
        {
            this.Clients.AddRange(
                new Client 
                {
                    Id = "1",
                    Name = "Marcos",
                    Email = "marcos@gmail.com",
                    UserName = "marcos@gmail.com"
                },
                new Client
                {
                    Id = "4",
                    Name = "Nicolas",
                    Email = "nicolas@gmail.com",
                    UserName = "nicolas@gmail.com"
                }
            );
            this.Technicians.AddRange(
                new Technician
                {
                    Id = "2",
                    Name = "Gaston",
                    Email = "gaston@gmail.com",
                    UserName = "gaston@gmail.com",
                    Available = true,
                    PasswordHash = "q",
                    PhoneNumber = "1",
                    NormalizedEmail = "gaston@gmail.com",
                    NormalizedUserName = "gaston@gmail.com",
                    SecurityStamp = "23",
                    LockoutEnd = DateTimeOffset.Now,
                    Response = "",
                    Role = "Tecnico"
                },
                new Technician
                {
                    Id = "3",
                    Name = "Mateo",
                    Email = "mateo@gmail.com",
                    UserName = "mateo@gmail.com",
                }
            );
            this.Admin.AddRange(
                new Admin
                {
                    Name = IdentityData.AdminName,
                    UserName = IdentityData.AdminUserName,
                    Email = IdentityData.AdminMail,
                    DOB = IdentityData.AdminDOB,
                    Role = IdentityData.AdminRoleName,
                    ListaFiltradaTechnicians = new List<Technician>()
                }
            );
        }
        public void GetRoles()
        {
            this.RoleWorker.AddRange(
                new RoleWorker
                {
                    ID = 1,
                    Title = "Camarografo",
                    Level = Level.Basico
                },

                new RoleWorker
                {
                    ID = 2,
                    Title = "Grabacion",
                    Level = Level.Avanzado
                },

                new RoleWorker
                {
                    ID = 3,
                    Title = "Sonidista",
                    Level = Level.Basico
                },
                new RoleWorker
                {
                    ID = 4,
                    Title = "Fotografo",
                    Level = Level.Avanzado
                }
            );
        }
        public void GetContracts()
        {
            this.Contract.AddRange(
                new ContractByDay
                {
                    Time = 8,
                    ClientId = "4",
                    TechnicianId = "3"
                }
            );
        }
    }
}
