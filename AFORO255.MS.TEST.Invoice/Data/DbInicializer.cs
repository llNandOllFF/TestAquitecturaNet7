using AFORO255.MS.TEST.Invoice.Models;
using AFORO255.MS.TEST.Invoice.Persistencia;

namespace AFORO255.MS.TEST.Invoice.Data
{
    public class DbInicializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Factura.Any()) return;

            var users = new Factura[]
            {
                    new Factura { Amount =3000M , Estado = 1 },
                    new Factura { Amount =10000M , Estado = 1 },
                    new Factura { Amount =15000M , Estado = 1 },
                    new Factura { Amount =20000M , Estado = 1 },
                    new Factura { Amount =30000M , Estado = 1 }
            };
            context.Factura.AddRange(users);
            context.SaveChanges();
        }
    }
}
