using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Server;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApiMySQLDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {

        //private readonly IHttpClientFactory _httpClientFactory;
        //private readonly HttpClient _client;

        //public OAuthController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}


        public IActionResult Token(string grant_type)
        {
            
            var key = Encoding.UTF8.GetBytes(Constanst.Secret);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, "192.168.82.139"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                //probamos que el refresco funcione
                Expires = grant_type == "refresh_token" ? DateTime.Now.AddMinutes(5) : DateTime.Now.AddMilliseconds(1),
                //Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            string bearer_token = tokenHandler.WriteToken(createdToken);
            return Ok(new { access_token = bearer_token });
        }

        //public async Task RefreshAccessToken()
        //{
        //    var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
        //    var refreshTokenClient = _httpClientFactory.CreateClient();

        //    var requestData = new Dictionary<string, string>
        //    {
        //        ["grant_type"] = "refresh_token",
        //        ["refresh_token"] = refreshToken
        //    };

        //    var Request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5001/api/OAuth")
        //    {
        //        Content = new FormUrlEncodedContent(requestData)
        //    };

        //    var basicCredentials = "username:password";
        //    var encodedCredentials = Encoding.UTF8.GetBytes(basicCredentials);
        //    var base64Credentials = Convert.ToBase64String(encodedCredentials);

        //    Request.Headers.Add("Authorization", $"Basic {base64Credentials}");

        //    //creamos la petición para validar el nuevo token (refresh token)
        //    var response = await refreshTokenClient.SendAsync(Request);

        //    //extraemos el nuevo token
        //    var responseString = await response.Content.ReadAsStringAsync();
        //    var responseData = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);

        //    //anualamos el token caducado y alamcenamos el nuevo token en la cookie sin tener que reenviar al proceso de validación

        //    //1º extraemos el token nuevo
        //    var newAccessToken = responseData.GetValueOrDefault("access_token");
        //    var newRefreshToken = responseData.GetValueOrDefault("refresh_token");

        //    //obtenemos la informacion de autentificacion y autoriracion a traves de la cookie
        //    var authInfo = await HttpContext.AuthenticateAsync("ClientCookie");

        //    //forzamos la actualizacion de la  autentificacion y autoriracion
        //    authInfo.Properties.UpdateTokenValue("access_token", newAccessToken);
        //    authInfo.Properties.UpdateTokenValue("refresh_token", newRefreshToken);

        //    //con el nuevo token lanzamos el login para guardar en la cookie esta nueva configuracion
        //    await HttpContext.SignInAsync("ClientCookie", authInfo.Principal, authInfo.Properties);
        //}
    }

   
}
