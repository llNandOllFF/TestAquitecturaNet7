using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Invoice.Messages.EventHandlers;
using AFORO255.MS.TEST.Invoice.Messages.Events;
using AFORO255.MS.TEST.Invoice.Persistencia;
using AFORO255.MS.TEST.Invoice.Service;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AFORO255.MS.TEST.Invoice.Infrastructure.Configurations
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddCustomDb(this IServiceCollection services, IConfiguration configuration)
        {
            var cnx = configuration.GetSection("cnx:postgres").Value;
            if (string.IsNullOrEmpty(cnx)) throw new Exception("CONTEXT : No esta definida la cadena de conexión");
            
            services.AddDbContext<AppDbContext>(options => { options.UseNpgsql(cnx); });
            return services;
        }
        public static IServiceCollection AddCustomDependencyInyections(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Program));
            services.AddScoped<IFacturaService, FacturaService>();
            services.AddTransient<InvoiceEventHandler>();
            services.AddTransient<IEventHandler<InvoiceCreatedEvent>, InvoiceEventHandler>();
            return services;
        }
        public static IServiceCollection AddCustomMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.Load("AFORO255.MS.TEST.Invoice"));
            return services;
        }
    }
}
