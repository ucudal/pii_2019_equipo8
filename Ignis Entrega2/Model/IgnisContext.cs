using Microsoft.EntityFrameworkCore;
using Ignis.Models;
using Ignis.Areas.Identity.Data;

namespace Ignis.Models
{
    public class IgnisContext : DbContext
    {
        public IgnisContext (DbContextOptions<IgnisContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Ignis.Models.RoleWorker> RoleWorker { get; set; }
        
       

    }
}