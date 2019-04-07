using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Service;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace WebAppUser
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IConfiguration configuration;

        public Startup(IHostingEnvironment env)
        {
            configuration = new ConfigurationBuilder().AddEnvironmentVariables().AddJsonFile(env.ContentRootPath+"/config.json",true).Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = configuration.GetConnectionString("UElectricsDBContext");
            services.AddMvc();
            services.AddMvcCore();
            services.AddAutoMapper();
           
            services.AddScoped(typeof(IGenericRepository<>), typeof(Repository<>));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc(
                routes =>
                {
                    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                }
            );
            app.UseStaticFiles();

        }
    }
}
