using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SahbindenBitirmeProjesi.Data.Context;
using SahbindenBitirmeProjesi.Data.Repositories.Concrete.EntityTypeRepositories;
using SahbindenBitirmeProjesi.Data.Repositories.Interfaces.EntityTypeRepositories;
using SahibindenBitirmeProjesi.Entity.Entities.Concrete;

namespace SahibindenBitirmeProjesi.Web
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
            services.AddMemoryCache();

            
            services.AddSession();


            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<ICarsRepository, CarsRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IModelsRepository, ModelsRepository>();

            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 3;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
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
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication(); 

            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                //4
                //endpoints.MapControllerRoute(
                //    "page",
                //    "{slug?}",
                //    defaults: new { controller = "Page", action = "Page" }
                //);

                //5
                endpoints.MapControllerRoute(
                    "model",
                    "model/{carsSlug}",
                    defaults: new { controller = "Model", action = "ModelsByCar" }
                );

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapControllerRoute(
                //    name: "areas",
                //    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                //    );

                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            
        }
    }
}
