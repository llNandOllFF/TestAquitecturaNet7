using AFORO255.MS.TEST.Pay.Models;
using Microsoft.EntityFrameworkCore;

namespace AFORO255.MS.TEST.Pay.Persistencia
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        public DbSet<Pago> Pago { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pago>();
        }
    }
}
