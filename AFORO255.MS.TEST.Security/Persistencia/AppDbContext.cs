using AFORO255.MS.TEST.Security.Models;
using Microsoft.EntityFrameworkCore;

namespace AFORO255.MS.TEST.Security.Persistencia
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
        }
    }
}
