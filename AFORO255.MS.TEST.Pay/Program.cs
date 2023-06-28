using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;
using Aforo255.Cross.Event.Src;
using Aforo255.Cross.Event.Src.Bus;
using Aforo255.Cross.Http.Src;
using AFORO255.MS.TEST.Pay.Data;
using AFORO255.MS.TEST.Pay.DTOs;
using AFORO255.MS.TEST.Pay.Infrastructure.Configuration;
using AFORO255.MS.TEST.Pay.Messages.Commands;
using AFORO255.MS.TEST.Pay.Service;
using AutoMapper;
using MediatR;
using System.Reflection;

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
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
builder.Services.AddRabbitMQ();
//builder.Services.AddProxyHttp();
builder.Services.AddConsul();
builder.Services.AddFabio();

var app = builder.Build();

//app.UseHttpsRedirection();

app.MapGet("ping", 
    async context => { 
        await context.Response.WriteAsync("Api Pay running... "); 
    });

app.MapGet("/api/pay/listar", (IPagoService pagoService) =>
{
    return Results.Ok(pagoService.Listar());
})
.Produces<IEnumerable<PagoDto>>();

app.MapPost("/api/pay/register", (PayRequest oPay,IPagoService pagoService, IEventBus eventBus, IMapper mapper) =>
{
    var oPago = pagoService.Agregar(oPay.IdInvoice, oPay.Amount);
   
    eventBus.SendCommand(mapper.Map<InvoiceCreateCommand>(oPago));
    eventBus.SendCommand(mapper.Map<TransactionCreateCommand>(oPago));

    return Results.Ok(oPago);
})
.Produces<PagoDto>();

app.UseConsul();

DbCreated.CreateDbIfNotExists(app);

app.Run();

record PayRequest (long IdInvoice,decimal Amount);