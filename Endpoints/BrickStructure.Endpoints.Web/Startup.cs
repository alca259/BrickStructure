using AutoMapper;
using BrickStructure.Data.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace BrickStructure.Endpoints.Web
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
            var coreBusinessLayerAssembly = typeof(BusinessLayerExtensions).Assembly;
            var clientBusinessLayerAssembly = typeof(ClientBusinessLayerExtensions).Assembly;
            var clientDataLayerAssembly = typeof(ClientDataLayerExtensions).Assembly;

            services.AddSingleton(s =>
            {
                return new AssemblyMappingName
                {
                    FullNames = new string[]
                    {
                        clientDataLayerAssembly.FullName
                    }
                };
            });

            services.RegisterApplicationContext(Configuration, "DefaultConnection");
            services.RegisterDefaultAgents();
            services.RegisterDefaultManagers();

            // Client
            services.RegisterClientAgents();
            services.RegisterClientManagers();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddLogging();

            // Automapper
            services.AddAutoMapper(coreBusinessLayerAssembly, clientBusinessLayerAssembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
