using AFORO255.MS.TEST.Security.Models;
using AFORO255.MS.TEST.Security.Persistencia;

namespace AFORO255.MS.TEST.Security.Data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context) 
        {
            context.Database.EnsureCreated();

            if (context.Users.Any()) return;

            var users = new User[]
            {
                    new User { UserName ="nando" , Password= "123456" }
            };
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
