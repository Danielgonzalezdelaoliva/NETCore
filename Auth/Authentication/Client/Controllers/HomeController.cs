using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _client;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Secret()
        {
            var serverResponse = await AccessTokenRefreshWrapper(() => SecuredGetRequest("https://localhost:44353/secret/index"));

            var apiResponse = await AccessTokenRefreshWrapper(() => SecuredGetRequest("https://localhost:44302/secret/index"));

            return View();
        }


        private async Task<HttpResponseMessage> SecuredGetRequest(string url)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            return await client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> AccessTokenRefreshWrapper(
            Func<Task<HttpResponseMessage>> initialRequest)
        {
            var response = await initialRequest();

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
               await RefreshAccessToken();
               response = await initialRequest();
            }

            return response;


        }

        private async Task RefreshAccessToken()
        {
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
            var refreshTokenClient = _httpClientFactory.CreateClient();

            var requestData = new Dictionary<string, string>
            {
                ["grant_type"] = "refresh_token",
                ["refresh_token"] = refreshToken
            };

            var Request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44353/OAuth/Token")
            {
                Content = new FormUrlEncodedContent(requestData)
            };

            var basicCredentials = "username:password";
            var encodedCredentials = Encoding.UTF8.GetBytes(basicCredentials);
            var base64Credentials = Convert.ToBase64String(encodedCredentials);

            Request.Headers.Add("Authorization", $"Basic {base64Credentials}");

            //creamos la petición para validar el nuevo token (refresh token)
            var response = await refreshTokenClient.SendAsync(Request);

            //extraemos el nuevo token
            var responseString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);

            //anualamos el token caducado y alamcenamos el nuevo token en la cookie sin tener que reenviar al proceso de validación

            //1º extraemos el token nuevo
            var newAccessToken = responseData.GetValueOrDefault("access_token");
            var newRefreshToken = responseData.GetValueOrDefault("refresh_token");

            //obtenemos la informacion de autentificacion y autoriracion a traves de la cookie
            var authInfo = await HttpContext.AuthenticateAsync("ClientCookie");

            //forzamos la actualizacion de la  autentificacion y autoriracion
            authInfo.Properties.UpdateTokenValue("access_token", newAccessToken);
            authInfo.Properties.UpdateTokenValue("refresh_token", newRefreshToken);

            //con el nuevo token lanzamos el login para guardar en la cookie esta nueva configuracion
            await HttpContext.SignInAsync("ClientCookie", authInfo.Principal, authInfo.Properties);
        }
    }
}
