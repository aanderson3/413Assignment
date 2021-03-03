using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore413.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bookstore413
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddEntityFrameworkSqlite();
            //create new service that adds db context and is passed in options
            services.AddDbContext<BookstoreDbContext>(options =>
            {
                //store the connection string to access database
                options.UseSqlite(Configuration["ConnectionStrings:BookstoreConnection"]);
            });

            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //category and page
                endpoints.MapControllerRoute("catpage",
                    "{category}/{page:int}",
                    new { Controller = "Home", action = "Index" });

                //only page
                endpoints.MapControllerRoute("page",
                    "{page:int}",
                    new { Controller = "Home", action = "Index" });

                //only category
                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1});

                //format page parameters in url to be Books/P#
                endpoints.MapControllerRoute(
                    "pagination",
                    "Books/P{page}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();
            });

            //pass in app to see if populated
            SeedData.EnsurePopulated(app);
        }
    }
}
