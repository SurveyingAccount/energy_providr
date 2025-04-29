using Microsoft.EntityFrameworkCore;
using energy_providr.Models;

namespace energy_providr.Data
{
    public class dtabaseContext : DbContext
    {
        public dtabaseContext(DbContextOptions<dtabaseContext> options)

        : base(options) { }

        public DbSet<Blogs> Blogs { get; set; }
        public DbSet<login_details> Users { get; set; }
        public DbSet<Booking> Booking { get; set; }
    }
}
