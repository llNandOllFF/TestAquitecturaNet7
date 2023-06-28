using Aforo255.Cross.Token.Src;
using AFORO255.MS.TEST.Security.Persistencia;
using AFORO255.MS.TEST.Security.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace AFORO255.MS.TEST.Security.Infrastructure.Configurations
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddCustomDb(this IServiceCollection services, IConfiguration configuration)
        {
            var cnx = configuration.GetSection("cnx:sql").Value;
            if (string.IsNullOrEmpty(cnx)) throw new Exception("CONTEXT : No esta definida la cadena de conexión");

            services.AddDbContext<AppDbContext>(options =>{ options.UseSqlServer(cnx); });
            return services;
        }
        
        public static IServiceCollection AddCustomDependencyInyections(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<IUserService, UserService>();
            services.Configure<JwtOptions>(configuration.GetSection("jwt"));

            //var secretKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("jwt:key"));
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            // {
            //     x.RequireHttpsMetadata = false;
            //     x.SaveToken = true;
            //     x.TokenValidationParameters = new TokenValidationParameters
            //     {
            //         ValidateIssuerSigningKey = true,
            //         IssuerSigningKey = new SymmetricSecurityKey(secretKey),
            //         ValidateIssuer = false,
            //         ValidateAudience = false
            //     };
            // });
             return services;
        }
        public static IServiceCollection AddCustomMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.Load("AFORO255.MS.TEST.Security"));
            return services;
        }
    }
}
