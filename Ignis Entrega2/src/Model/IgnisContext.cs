using Microsoft.EntityFrameworkCore;
using Ignis.Models;
using Ignis.Areas.Identity.Data;

//Este contexto guarda en la base de datos los objetos del tipo RoleWorker que sirven para
//que los vea el administrador 
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