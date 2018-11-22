using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TandVark.Domain.Models;
using TandVark.Domain.Repositories;
using TandVark.Domain.Repositories.Interfaces;
using TandVark.Data.Data1;
using TandVark.Domain.Services;
using TandVark.Domain.Services.Interfaces;
using TandVark.Domain.Helpers.Interfaces;
using TandVark.Domain.Helpers;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TandVark_ASP.NETCORE_REACT.Middlewares;

namespace TandVark_ASP.NETCORE_REACT
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
            //STORA DATORN
            //
            //services.AddDbContext<TandVerkContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TandVark;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"));

            //LILLA DATORN
            services.AddDbContext<TandVerkContext>(options => options.UseSqlServer("Data Source=LAPTOP-TU1UMOIC\\SQLEXPRESS;Initial Catalog=TandVerk;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            
            //IN MEMORY DATABAS DEMO
            //services.AddDbContext<TandVerkContext>(options =>
            //{
            //    options.UseInMemoryDatabase("TestDb");
            //    options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            //});

            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IPatientServices, PatientServices>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDentistServices, DentistServices>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IHelperValidationSSN, HelperValidationSSN>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseMiddleware<RequestResponseLoggerMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
