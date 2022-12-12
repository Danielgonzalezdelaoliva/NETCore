using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("OAuth")
                .AddJwtBearer("OAuth", config =>
               {
                   var secretBytes = Encoding.UTF8.GetBytes(Constanst.Secret);
                   var key = new SymmetricSecurityKey(secretBytes);

                   #region Validar token en la URL como un parametro

                   config.Events = new JwtBearerEvents()
                   {
                       OnMessageReceived = context =>
                       {
                           if (context.Request.Query.ContainsKey("access_token"))
                           {
                               context.Token = context.Request.Query["access_token"];
                           }

                           return Task.CompletedTask;
                       }
                   };

                   #endregion

                   #region Validar token en el encabezador (header)

                   config.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ClockSkew = TimeSpan.Zero,
                       ValidIssuer = Constanst.Issuer,
                       ValidAudience = Constanst.Audiance,
                       IssuerSigningKey = key,
                   };

                   #endregion

               });


            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
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
                //endpoints.MapRazorPages();
            });
        }
    }
}
