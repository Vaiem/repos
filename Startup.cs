using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BlogDesing.Models;
using Microsoft.Extensions.Configuration;

namespace BlogDesing
{
    public class Startup
    {
        IConfiguration Config;
        public Startup(IConfiguration config)
        {
            Config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContextAll>(option =>
            option.UseSqlServer(Config["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<DbContextIdent>(options => 
            options.UseSqlServer(Config["StoreIdentity:ConnectionStrings"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                 .AddEntityFrameworkStores<DbContextIdent>()
                 .AddDefaultTokenProviders();
            services.AddTransient<IRepositoryAutor, ReposytoryAutor>();
            services.AddTransient<IRepositoryDesign, RepositoryDesign>();
            services.AddTransient<IRegistration, Registration>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc(option => option.MapRoute(
                name: null,
                template: "{categoria}/{page:int}",
                defaults: new { controller = "Home", action = "Index" }));
            app.UseMvcWithDefaultRoute();

            DefaultSeed.Seed(app);
        }
    }
}
