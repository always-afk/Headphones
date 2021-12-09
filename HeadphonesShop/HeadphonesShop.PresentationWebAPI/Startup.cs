using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HeadphonesShop.BusinessLogic.Services.Implementation;
using HeadphonesShop.BusinessLogic.Services.Interfaces;
using HeadphonesShop.DataAccess.Context;
using HeadphonesShop.DataAccess.Repository.Implementation;
using HeadphonesShop.DataAccess.Repository.Interfaces;
using HeadphonesShop.PresentationWebAPI.Services.Implementation;
using HeadphonesShop.PresentationWebAPI.Services.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace HeadphonesShop.PresentationWebAPI
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
            var connection = Configuration.GetConnectionString("DefaultConnection");
            var googleAuthIIS = Configuration.GetSection("GoogleAuthentication").GetSection("IISExpress");
            var googleId = googleAuthIIS.GetSection("ClientId").Value;
            var googleSecret = googleAuthIIS.GetSection("ClientSecret").Value;

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie()
                .AddGoogle(options =>
                {
                    options.ClientId = googleId;
                    options.ClientSecret = googleSecret;
                });

            services.AddDbContext<HeadphonesDBContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICompaniesRepository, CompaniesRepository>();
            services.AddScoped<IDesignRepository, DesignRepository>();
            services.AddScoped<IHeadphonesRepository, HeadphonesRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IHeadphonesService, HeadphonesService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IDesignService, DesignService>();
            services.AddScoped<IFileWorker, FileWorker>();

            services.AddScoped<INavigationService, NavigationService>();

            services.AddAutoMapper(typeof(Mapping.MapProfile), typeof(BusinessLogic.Mapping.MapProfile));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
