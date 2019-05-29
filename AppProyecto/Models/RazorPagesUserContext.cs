using Microsoft.EntityFrameworkCore;

namespace AppProyecto.Models
{
    public class RazorPagesUserContext : DbContext
    {
        public RazorPagesUserContext (DbContextOptions<RazorPagesUserContext> options)
            : base(options)
        {
        }

        public DbSet<AppProyecto.Models.User> User { get; set; }
    }
}

