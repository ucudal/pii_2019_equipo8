// using Microsoft.EntityFrameworkCore;
// using AppProyecto.Models;

// namespace RazorPagesMovie.Models
// {
//     public class RazorPagesUserContext : DbContext
//     {
//         public RazorPagesUserContext (DbContextOptions<RazorPagesUserContext> options)
//             : base(options)
//         {
//         }

//         public DbSet<User> User { get; set; }
//         public DbSet<Role> Roles {get; set;}
//         public DbSet<Worker> Workers { get; set; }
//         public DbSet<RoleAssignment> RoleAssignments { get; set; }


//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             modelBuilder.Entity<Role>().ToTable("Role");
//             modelBuilder.Entity<Client>().ToTable("Client");
//             modelBuilder.Entity<Worker>().ToTable("Worker");
//             modelBuilder.Entity<RoleAssignment>().ToTable("RoleAssignment");

//             modelBuilder.Entity<RoleAssignment>()
//                 .HasKey(c => new { c.RoleID, c.WorkerID });
//         }








//     }
// }

