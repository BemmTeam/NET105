using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NET105.Helper;
using NET105.Interface;
using NET105.Repository;

namespace NET105
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
            services.AddDbContext<ShopContext>(option => 
            option.UseSqlServer(Configuration.GetConnectionString("Shop")));

            // add session
            services.AddSession(option => option.IdleTimeout = TimeSpan.FromMinutes(90));

            services.AddTransient<IProduct,ProductRepository>();
            services.AddTransient<ICategory,CategoryRepository>();
            services.AddTransient<IPayment,PaymentRepository>();
            services.AddTransient<Icart,CartRepository>();
            services.AddTransient<IUser,UserRepository>();


            // Add helpder
            services.AddScoped<IUploadHelper , UploadHelper>();


            // bật cors
            services.AddCors(c => c.AddPolicy("AllowOrigin" , option => option.AllowAnyOrigin()));
  services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().WithMethods("PUT", "DELETE", "GET" , "POST").AllowAnyHeader()));

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
            app.UseSession();
            app.UseRouting();
            app.UseCors(option => option.AllowAnyOrigin());
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
