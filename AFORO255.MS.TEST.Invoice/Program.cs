using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;
using Aforo255.Cross.Event.Src;
using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Invoice.Data;
using AFORO255.MS.TEST.Invoice.DTOs;
using AFORO255.MS.TEST.Invoice.Infrastructure.Configurations;
using AFORO255.MS.TEST.Invoice.Messages.EventHandlers;
using AFORO255.MS.TEST.Invoice.Messages.Events;
using AFORO255.MS.TEST.Invoice.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((host, builder) =>
{
    var c = builder.Build();
    builder.AddNacosConfiguration(c.GetSection("nacosConfig"));
});

var configuration = builder.Configuration;

builder.Services.AddCustomDb(configuration);
builder.Services.AddCustomDependencyInyections();
builder.Services.AddCustomMapper();
builder.Services.AddRabbitMQ();
builder.Services.AddConsul();
builder.Services.AddFabio();

var app = builder.Build();

//app.UseHttpsRedirection();

app.MapGet("/ping", 
    async context => { 
        await context.Response.WriteAsync("Api Invoice running... ");
    });

app.MapGet("/api/invoice", (IFacturaService facturaService) =>
{
    return Results.Ok(facturaService.Listar());
})
.Produces<IEnumerable<FacturaDto>>();

app.UseConsul();
DbCreated.CreateDbIfNotExists(app);

ConfigureEventBus(app);
app.Run();
void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    eventBus.Subscribe<InvoiceCreatedEvent, InvoiceEventHandler>();
}