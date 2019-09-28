using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserService.Infra.Context;
using UserService.Infra.Repositories;
using UserService.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Service.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace UserService
{
    public static class Setup
    {
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddScoped<DataContext, DataContext>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IVeiculoRepository, VeiculoRepository>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<UsuarioService, UsuarioService>();
        }

        public static void ConfigureMigrations(this IApplicationBuilder app, DataContext context)
        {
            context.Database.Migrate();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Documentação API - FRETEJA",
                    Description = ""
                });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = "header",
                    Name = "Authorization",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(security);
            });
        }

    }
}
