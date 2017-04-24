using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CES_DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using CES_DAL.Models.UsersEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CES_WebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.

            services.AddDbContext<SchoolContext>( options => 
                options.UseSqlServer(Configuration.GetConnectionString( "DefaultConnection" )) );
            services.AddDbContext<AppIdentityContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            services.AddIdentity<AppUser, IdentityRole>(opts => {
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;

                opts.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnmйцукенгшщзхъфывапролджэячсмитьбю1234567890";
            }).AddEntityFrameworkStores<AppIdentityContext>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, SchoolContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseIdentity();
            #region Custom Cookies
            //app.UseCookieAuthentication(new CookieAuthenticationOptions() {
            //    AuthenticationScheme = "MyAuthMiddleware",
            //    LoginPath = new PathString("/Account/Unauthorized"),
            //    AccessDeniedPath = new PathString("/Account/Forbidden"),
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge  = true

            //    }); 
            #endregion


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

       //     DbInitializer.Initialize(context);
        }
    }
}