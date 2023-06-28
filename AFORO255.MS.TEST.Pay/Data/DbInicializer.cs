using AFORO255.MS.TEST.Pay.Models;
using AFORO255.MS.TEST.Pay.Persistencia;

namespace AFORO255.MS.TEST.Pay.Data
{
    public class DbInicializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            //if (context.Pago.Any()) return;

            //var pays = new Pago[]
            //{
            //        new Pago { IdInvoice = 1,Amount =30M ,Date = DateTime.Now }
            //};
            //context.Pago.AddRange(pays);
            //context.SaveChanges();
        }
    }
}
