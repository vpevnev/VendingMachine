using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VendingMachine.Infrastructure.Extensions;
using VendingMachine.Services;

namespace VendingMachine
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMachine(Configuration);

            services.AddHttpContextAccessor();
            services.AddTransient<ISession>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.Session);
            services.AddTransient<ISessionService, SessionService>();
            services.AddSession();

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Machine}/{action=Index}/{id?}");
            });
        }
    }
}
