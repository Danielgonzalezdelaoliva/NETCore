using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //configuramos los endpoint que necesitan autentificacion

            services.AddAuthentication(config=>
            {
                //revisamos la cookie para confirmar que estamos autenticados
                config.DefaultAuthenticateScheme = "ClientCookie";                
                //despues de logarnos repartimos la cookie
                config.DefaultSignInScheme = "ClientCookie";
                //uso para verificar que estamos permitidos para hacer algo
                config.DefaultChallengeScheme = "OurServer";

            })
                .AddCookie("ClientCookie")

                //configuramos los endpoint que necesitan auterizacion
                .AddOAuth("OurServer", config =>
                {
                    config.ClientId = "client_id";
                    config.ClientSecret = "client_secret";
                    config.CallbackPath = "/OAuth/callback";        
                    //el servidor nos proporcionara la configuracion de la autorización
                    config.AuthorizationEndpoint = "https://localhost:44353/OAuth/Authorize";

                    //el endopoint token del servidor nos emitirá un token
                    config.TokenEndpoint = "https://localhost:44353/OAuth/Token";

                    config.SaveTokens = true;

                    config.Events = new OAuthEvents()
                    {
                        OnCreatingTicket = context =>
                        {
                            var accessToken = context.AccessToken;
                            var base64payload = accessToken.Split(".")[1];
                            var bytes = Convert.FromBase64String(base64payload);
                            var jsonPayload = Encoding.UTF8.GetString(bytes);
                            var claims = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonPayload);

                            foreach(var claim in claims)
                            {
                                context.Identity.AddClaim(new Claim(claim.Key, claim.Value));
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddHttpClient();

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
            });
        }
    }
}
