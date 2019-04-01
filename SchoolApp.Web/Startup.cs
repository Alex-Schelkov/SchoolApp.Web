
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using SchoolApp.Web.Base;

namespace SchoolApp.Web
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
            services.AddDbContext<ApplicationDbContext>(options =>
          options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
         
           
            
            services.Configure<CookiePolicyOptions>(options =>
             {
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizePage("/Admin/login");

                });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

     
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
          

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

  

            app.UseStaticFiles(); 
    

            app.UseAuthentication();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
