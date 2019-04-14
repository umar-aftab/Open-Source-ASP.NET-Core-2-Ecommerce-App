using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service;
using CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AdminApp
{
    public class Startup
    {
        private IConfigurationRoot configuration;

        public Startup(IHostingEnvironment env)
        {
            configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile(env.ContentRootPath + "/config.json")
                .AddJsonFile(env.ContentRootPath + "/config.development.json", true)
                .Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = configuration.GetConnectionString("UElectricsDBContext");
            services.AddMvc();
            services.AddMvcCore();
            //services.AddAutoMapper();
            services.AddDbContext<ContextEntities>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                }
            );
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                    options =>
                    {
                        options.AccessDeniedPath = new PathString("/AdminUser/AddFacility");
                        options.AccessDeniedPath = new PathString("/AdminUser/AddFacilityEmployee");
                        options.AccessDeniedPath = new PathString("/AdminUser/Index");
                        options.AccessDeniedPath = new PathString("/AdminUser/Login");
                        options.AccessDeniedPath = new PathString("/AdminUser/ViewFacilities");
                        options.AccessDeniedPath = new PathString("/AdminUser/ViewFacilityEmployees");
                        options.AccessDeniedPath = new PathString("/AdminUser/ViewOrders");
                        options.AccessDeniedPath = new PathString("/AdminUser/ViewProducts");
                        options.AccessDeniedPath = new PathString("/AdminUser/ViewReviews");
                        options.AccessDeniedPath = new PathString("/AdminUser/ViewUsers");
                        options.LoginPath = new PathString("/AdminUser/Login");
                    }
                );
            services.AddScoped(typeof(IGenericRepository<>), typeof(Repository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
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
