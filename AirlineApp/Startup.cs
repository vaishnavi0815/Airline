using AirlineApp.Repository.Admin;
using AirlineApp.Repository.AirlineStaff;
using AirlineApp.Repository.Model;
using AirlineApp.Repository.User;
using AirlineApp.Services.Admin;
using AirlineApp.Services.AirlineStaff;
using AirlineApp.Services.User;
using ApnaAahar.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineApp
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
            services.AddControllers();
            services.AddCors();
            services.AddDbContextPool<airlinedbContext>(options => options.UseMySQL(Configuration.GetConnectionString("LocalDBContext")));

            //services.AddDbContextPool<AirlineContext>(options =>
            //{
            //    options.UseMySQL(
            //       Configuration.GetConnectionString("LocalDBContext"),
            //        .AutoDetect(Configuration.GetConnectionString("LocalDBContext")),
            //        options => options.EnableRetryOnFailure(
            //            maxRetryCount: 5,
            //            maxRetryDelay: System.TimeSpan.FromSeconds(30),
            //            errorNumbersToAdd: null)
            //        );
            //});

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Airline API",
                    Description = "Documentation for Airline API ",
                    Version = "v1"
                });
            });
            //services.AddMvc().AddNewtonsoftJson();
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IAirlineStaffService, AirlineStaffService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAdminData, AdminData>();
            services.AddTransient<IAirlineStaffData, AirlineStaffData>();
            services.AddTransient<IUserData, UserData>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(options => options.SetIsOriginAllowed(allow => _ = true).AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger(c =>
            {
            });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AirlineApp");
            });
        }
    }
}
