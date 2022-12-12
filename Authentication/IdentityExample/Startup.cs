using IdentityExample.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDBContext>(config =>
            {
                config.UseInMemoryDatabase("Memory");
            });

            //para generar todas las configuraciones de la autentificacion (usuario, contraseña, email, claims, etc)
            services.AddIdentity<IdentityUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireDigit = false;
                config.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<AppDBContext>() // hace de puente entre la base de datos(guardar, recuperar) y el objeto identidad (un poco dudoso?)
                .AddDefaultTokenProviders(); //es obligatorio incluirlo

            //para configurar la cookie para dar agregar identidad
            services.ConfigureApplicationCookie(confing =>
            {
                confing.Cookie.Name = "Identity.Cookie";
                confing.LoginPath = "/Home/Login"; //rediriges la aplicacin al punto de loging si el endpoint esta con autorización
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();

            //quien eres?
            app.UseAuthentication();

            //estas permitido?
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
