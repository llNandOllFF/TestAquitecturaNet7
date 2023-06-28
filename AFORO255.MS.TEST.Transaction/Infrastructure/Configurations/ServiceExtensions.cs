using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Transaction.Messages.EventHandlers;
using AFORO255.MS.TEST.Transaction.Messages.Events;
using AFORO255.MS.TEST.Transaction.Persistencia;
using AFORO255.MS.TEST.Transaction.Persistencia.Settings;
using AFORO255.MS.TEST.Transaction.Service;
using MediatR;
using System.Reflection;

namespace AFORO255.MS.TEST.Transaction.Infrastructure.Configurations
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomDb(this IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<Mongosettings>(opt =>
            {
                opt.Connection = configuration.GetSection("cnx:mongo").Value;
                opt.DatabaseName = configuration.GetSection("db:mongo").Value;
            });
            return services;
        }
        public static IServiceCollection AddCustomDependencyInyections(this IServiceCollection services)
        {
            services.AddScoped<IMongoBookDBContext, MongoBookDBContext>();
            services.AddScoped<IOperacionService, OperacionService>();
            services.AddMediatR(typeof(Program));
            services.AddTransient<TransactionEventHandler>();
            services.AddTransient<IEventHandler<TransactionCreatedEvent>, TransactionEventHandler>();
            return services;
        }
        public static IServiceCollection AddCustomMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.Load("AFORO255.MS.TEST.Transaction"));
            return services;
        }
    }
}
