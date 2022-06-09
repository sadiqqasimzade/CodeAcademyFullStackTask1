using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NestBack.DAL;
using NestBack.Models;
using NestBack.Services;
using NestBack.Utilies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NestBack
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
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:Default"]);
            });
            services.AddSession(opt=>opt.IdleTimeout = TimeSpan.FromHours(1));
            services.AddHttpContextAccessor();
            services.AddScoped<LayoutServices>();
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = false;
                opt.User.RequireUniqueEmail = true;
                opt.Lockout.MaxFailedAccessAttempts = 3;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            }
            );
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Auth/LogIn");
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
            app.UseSession();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            Constants.ProductImgPath = System.IO.Path.Combine(env.WebRootPath, "imgs", "products");
            Constants.ProductImgMaxSizeInKb = 1024;
            Constants.ProductNameMaxLength=20;
            
            Constants.CategoryImgPath = System.IO.Path.Combine(env.WebRootPath, "imgs", "categoryicons");
            Constants.CategoryImgMaxSizeInKb = 1024;
            Constants.CategoryNameMaxLength=20;
            
            Constants.SliderImgPath = System.IO.Path.Combine(env.WebRootPath, "imgs", "slider");
            Constants.SliderImgMaxSizeInKb = 1024;
            Constants.SliderNameMaxLength=20;
        }
    }
}
