
using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;
using Aforo255.Cross.Event.Src;
using Aforo255.Cross.Event.Src.Bus;
using AFORO255.MS.TEST.Transaction.DTOs;
using AFORO255.MS.TEST.Transaction.Infrastructure.Configurations;
using AFORO255.MS.TEST.Transaction.Messages.EventHandlers;
using AFORO255.MS.TEST.Transaction.Messages.Events;
using AFORO255.MS.TEST.Transaction.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((host, builder) =>
{
    var c = builder.Build();
    builder.AddNacosConfiguration(c.GetSection("nacosConfig"));
});

var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddCustomDb(configuration);
builder.Services.AddCustomDependencyInyections();
builder.Services.AddCustomMapper();
builder.Services.AddRabbitMQ();
builder.Services.AddConsul();
builder.Services.AddFabio();

var app = builder.Build();

//app.UseHttpsRedirection();

app.MapGet("ping", async context => { await context.Response.WriteAsync("Api Transaction running... "); });

app.MapGet("/api/transaction/listar", ([AsParameters] OperacionSearch oOperacionSearch,IOperacionService operacionService) =>
{
    var aaa = operacionService.GetById(oOperacionSearch.IdInvoice).Result;
    return Results.Ok(aaa);
})
.Produces<IEnumerable<OperacionDto>>();

app.MapPost("/api/transaction/operacion", (OperacionRequest oOperacionReq, IOperacionService operacionService) =>
{    
    return Results.Ok(operacionService.Add(oOperacionReq).Result);
})
.Produces<OperacionDto>()
.WithName("Operacion");

app.UseConsul();
ConfigureEventBus(app);
app.Run();

void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    eventBus.Subscribe<TransactionCreatedEvent, TransactionEventHandler>();
}