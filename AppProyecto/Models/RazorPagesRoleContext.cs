using Microsoft.EntityFrameworkCore;

namespace AppProyecto.Models
{
    public class RazorPagesRoleContext : DbContext
    {
        public RazorPagesRoleContext (DbContextOptions<RazorPagesRoleContext> options)
            : base(options)
        {
        }

        public DbSet<AppProyecto.Models.Role> Role { get; set; }
    }
}

