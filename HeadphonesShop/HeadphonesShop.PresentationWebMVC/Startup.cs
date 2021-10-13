using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeadphonesShop.DataAccess.Context;
using HeadphonesShop.DataAccess.Repository.Implementation;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using HeadphonesShop.DataAccess.Services.Implementation;
using HeadphonesShop.DataAccess.Services.Interfaces;
using HeadphonesShop.BusinessLogic.Services.Implementation;
using HeadphonesShop.BusinessLogic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HeadphonesShop.PresentationWebMVC
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie()
                .AddGoogle(options =>
                {
                    options.ClientId = "525136855843-vdr9s9c33l9hnn75tdqgc2md5t7tda19.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                });
            //services.AddDbContext<HeadphonesDBContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<HeadphonesDBContext>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
            services.AddScoped<IDesignRepository, DesignRepository>();
            services.AddScoped<IHeadphonesRepository, HeadphonesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMapper, Mapper>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IHeadphonesService, HeadphonesService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDesignService, DesignService>();

            services.AddControllersWithViews();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
            });
        }
    }
}
