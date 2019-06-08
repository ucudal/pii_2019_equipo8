using Microsoft.EntityFrameworkCore;
using Ignis.Models;

namespace Ignis.Models
{
    public class IgnisContext : DbContext
    {
        public IgnisContext (DbContextOptions<IgnisContext> options)
            : base(options)
        {
        }

        public DbSet<Ignis.Models.Movie> Movie { get; set; }

        public DbSet<Ignis.Models.Actor> Actor { get; set; }

        public DbSet<Appereance> Appereances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appereance>().ToTable("Appereance")
                 .HasKey(a => new { a.ActorID, a.MovieID });
        }
    }
}