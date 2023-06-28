using AFORO255.MS.TEST.Pay.Messages.CommandHandlers;
using AFORO255.MS.TEST.Pay.Messages.Commands;
using AFORO255.MS.TEST.Pay.Persistencia;
using AFORO255.MS.TEST.Pay.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AFORO255.MS.TEST.Pay.Infrastructure.Configuration
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomDb(this IServiceCollection services, IConfiguration configuration)
        {
            var cnx = configuration.GetSection("cnx:mysql").Value;
            if (string.IsNullOrEmpty(cnx)) throw new Exception("CONTEXT : No esta definida la cadena de conexión");

            services.AddDbContext<AppDbContext>(options => { options.UseMySQL(cnx); });
            return services;
        }
        public static IServiceCollection AddCustomDependencyInyections(this IServiceCollection services)
        {
            services.AddScoped<IPagoService, PagoService>();
            services.AddTransient<IRequestHandler<TransactionCreateCommand, bool>, TransactionCommandHandler>();
            services.AddTransient<IRequestHandler<InvoiceCreateCommand, bool>, InvoiceCommandHandler>();
            return services;
        }
        public static IServiceCollection AddCustomMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.Load("AFORO255.MS.TEST.Pay"));
            return services;
        }
    }
}
