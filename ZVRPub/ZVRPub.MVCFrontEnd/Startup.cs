using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using NLog;

namespace ZVRPub.MVCFrontEnd
{
    public class Startup
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public Startup(IConfiguration configuration)
        {
            log.Info("Setting up configuration");
            Configuration = configuration;
            log.Info("Configuration set up");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            log.Info("Setting up cookie policy");
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            log.Info("Register httpclient");
            services.AddSingleton(sp => new HttpClient(new HttpClientHandler { UseCookies = false }));

            log.Info("Register MVC and setting compatibility version");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            log.Info("Registration complete");

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<Settings>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            log.Info("Marking application as 'in development'");
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                log.Info("Error detected: mvc not marked as in development - launching error view");
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            log.Info("Routing to home index page");
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
