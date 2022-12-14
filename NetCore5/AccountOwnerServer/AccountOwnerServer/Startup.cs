using AccountOwnerServer.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Configuration;
using System.IO;

namespace AccountOwnerServer
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //agremos servicio para deshabilitar la resticciones Cors
            services.ConfigureCors();

            //agregamos servicio para configuraci�n personalizado de IIS
            services.ConfigureIISIntegration(); 

            //agregamos el registro de errores (log) solo una instancia por ejecuci�n
            services.ConfigureLoggerService();

            //agregamos servicio para visualizar controllers
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
