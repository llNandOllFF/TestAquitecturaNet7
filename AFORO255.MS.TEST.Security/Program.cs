using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;
using AFORO255.MS.TEST.Security.Data;
using AFORO255.MS.TEST.Security.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((host, builder) =>
{
    var c = builder.Build();
    builder.AddNacosConfiguration(c.GetSection("nacosConfig"));
});

var configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomDb(configuration);
builder.Services.AddCustomDependencyInyections(configuration);
builder.Services.AddCustomMapper();
builder.Services.AddConsul();
builder.Services.AddFabio();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseHttpsRedirection();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "dafault",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapGet("ping", async context => { await context.Response.WriteAsync("Api Security running... "); });
});
app.UseConsul();
DbCreated.CreateDbIfNotExists(app);

app.Run();