using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class OAuthController : Controller
    {
        [HttpGet]
        public IActionResult Authorize(
            string response_type,
            string client_id,
            string redirect_uri,
            string scope,
            string state)
        {
            var query = new QueryBuilder();
            query.Add("redirectUri", redirect_uri);
            query.Add("state", state);

            return View(model: query.ToString());
        }

        [HttpPost]           
        public IActionResult Authorize(
            string username,
            string redirectUri,
            string state
            )
        {
            const string code = "REREREREJKEPE";

            var query = new QueryBuilder();
            query.Add("code", code);
            query.Add("state", state);

            return Redirect($"{redirectUri}{query.ToString()}");
        }

        public async Task<IActionResult> Token (
            string grant_type, // flujo de acceso de la petición del token
            string code, // confirmación del proceso de autenticación
            string  redirect_uri,
            string client_id,
            string refresh_token
            )
        {
            //algun proceso para validar el code
            var claims = new[]
            {
                new  Claim(JwtRegisteredClaimNames.Sub, "some_id"),
                new  Claim("granny", "cookie")
            };
            var secretBytes = Encoding.UTF8.GetBytes(Constanst.Secret);
            var key = new SymmetricSecurityKey(secretBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                Constanst.Issuer,
                Constanst.Audiance,
                claims,
                notBefore: DateTime.Now,
                //si el tipo de concesión es refres => aumentamos el tiempo de validación del token.
                //para este ejemplo forzamos el refresco del token para ver como se procede para actualizar un token caducado (= AddMilliseconds(1))
                expires: grant_type == "refresh_token" ? DateTime.Now.AddMinutes(5) : DateTime.Now.AddMilliseconds(1),
                signingCredentials
                );

            var access_token = new JwtSecurityTokenHandler().WriteToken(token);

            var responseObject = new
            {
                access_token,
                token_type = "Bearer",
                raw_claim = "oauthTutorial",
                refresh_token = "RefreshTokenSampleValueSomething77"
            };

            var responseJson = JsonConvert.SerializeObject(responseObject);
            var responseBytes = Encoding.UTF8.GetBytes(responseJson);

            await Response.Body.WriteAsync(responseBytes, 0, responseBytes.Length);

            return Redirect(redirect_uri);
        }

        [Authorize]
        public IActionResult Validate()
        {
            if(HttpContext.Request.Query.TryGetValue("access_token", out var accesstoken))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
