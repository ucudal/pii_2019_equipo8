using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Models
{
    public class RazorPagesMovieContext : DbContext
    {
        public RazorPagesMovieContext (DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<WorkerRole> Roles {get; set;}
        //public DbSet<RoleAssignment> RoleAssignments { get; set; }
        public DbSet<RazorPagesMovie.Areas.Identity.Data.Tecnico> Tecnicos { get; set; }


        // public DbSet<RazorPagesMovie.Areas.Identity.Data.ApplicationWorker> ApplicationWorker {get;set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WorkerRole>().ToTable("Role");
        modelBuilder.Entity<RazorPagesMovie.Areas.Identity.Data.Tecnico>().ToTable("Worker");
        //modelBuilder.Entity<RoleAssignment>().ToTable("RoleAssignment");

        // modelBuilder.Entity<RoleAssignment>()
        //     .HasKey(c => new { c.RoleID, c.WorkerID });
    }
        //public DbSet<Worker> Workers { get; set; }


        // public DbSet<RazorPagesMovie.Areas.Identity.Data.ApplicationWorker> ApplicationWorker {get;set;}
    }
}