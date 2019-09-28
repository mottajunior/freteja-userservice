using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using UserService.ErrorHandler;
using UserService.Infra.Context;

namespace UserService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddEntityFrameworkNpgsql().AddDbContext<DataContext>(options => options.UseNpgsql(Configuration.GetConnectionString("connStr"), m => m.MigrationsAssembly("UserService")));
            services.ConfigureDbContext();
            services.ConfigureRepositories();
            services.ConfigureServices();
            services.ConfigureSwagger();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataContext context)
        {
            app.UseSwaggerUI(c =>
            {
                string Url = "/swagger/v1/swagger.json";
                c.SwaggerEndpoint(Url, "API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseSwagger();
            app.UseErrorHandling();
            app.ConfigureMigrations(context);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
