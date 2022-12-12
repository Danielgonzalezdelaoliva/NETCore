using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolaApi
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
            services.AddRazorPages();
            services.AddControllers();

            //para agrergar la dependencia en el Ioc
            services.AddTransient<MyCustomMiddleware1>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //codificación para llamar entre diferentes middelwares
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Getting Response from 1st Middleware \n");
            //    await next();
            //});
            //app.Run(async context => {
            //    await context.Response.WriteAsync("Response Response from second Middleware \n");
            //});


            //codificación para llamar entre diferentes middelwares. Versión avanzada
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Use Middleware1 Incoming Request \n"); //orden ejecución : 1
            //    await next();
            //    await context.Response.WriteAsync("Use Middleware1 Outgoing Response \n"); //orden ejecución : 5
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Use Middleware2 Incoming Request \n"); //orden ejecución : 2
            //    await next();
            //    await context.Response.WriteAsync("Use Middleware2 Outgoing Response \n"); //orden ejecución : 4
            //});
            //app.Run(async context => {
            //    await context.Response.WriteAsync("Run Middleware3 Request Handled and Response Generated\n"); //orden ejecución : 3
            //});

            //codificación para llamar a un middleware en función de un URL especifica
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Use Middleware Component \n");
            //    await next();
            //});

            ////para configurar un middelware en función de la URL especificada.
            ////Para este caso si la URL tiene parte "/testmap", el nuevo middleware será configurado.
            //app.Map("/testmap", MapCustomMiddleware);
            //app.Run(async context => {
            //    await context.Response.WriteAsync("Run Middleware Component\n");
            //});

            //Codificación para customizar  un middelware
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Use Middleware Incoming Request \n");
                await next();
                await context.Response.WriteAsync("Use Middleware Outgoing Response \n");
            });
            app.UseMiddleware<MyCustomMiddleware1>();
            app.Run(async context => {
                await context.Response.WriteAsync("Run Middleware Component\n");
            });





            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            
            

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

                endpoints.MapControllers();
            });
        }



        private void MapCustomMiddleware(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Specific URL Logic Middleware \n");
            });
        }
    }
}
