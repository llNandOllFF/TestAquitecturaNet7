using AFORO255.MS.TEST.Invoice.Models;
using Microsoft.EntityFrameworkCore;

namespace AFORO255.MS.TEST.Invoice.Persistencia
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options) { }

        public DbSet<Factura> Factura { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>();
        }
    }
}
