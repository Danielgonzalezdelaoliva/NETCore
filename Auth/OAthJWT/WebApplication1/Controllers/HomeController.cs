using Mecalux.Core.Authentication.Client.Contracts;
using Mecalux.Core.Authentication.Client.Services;
using Mecalux.Core.Domain.Entities.JWT;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class HomeController : ApiController
    {
        // GET: api/Home
        public async Task<IEnumerable<string>> GetAsync()
        {

            //var oAuthConfiguration = new OAuthConfiguration()
            //{
            //    ApiBaseAddress = "https://int-login.mecalux.com/",
            //    ApiKey = "005a64dfc1e440f18c7528d5837033b1",
            //    AppId = "421c2d5bd86d4ba2817907ac2c24d3b9"
            //};
            //IHttpClient httpServer = new Mecalux.Core.Authentication.Client.Services.HttpClient(oAuthConfiguration);
            //IOAuthServer clientMecalux = new OAuthServer(oAuthConfiguration, httpServer);
            //var token = clientMecalux.Token;

            ////lanzamos la petición con el token
            //using (var client = new System.Net.Http.HttpClient())
            //{
            //    var url = "https://www.theidentityhub.com/api/identity/v1";
            //    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.AccessToken);
            //    var response = await client.GetAsync(url);

            //    // Parse JSON response.

            //}

            using (var client = new System.Net.Http.HttpClient())
            {


                var url = "https://localhost:5001/api/OAuth";
                var response = await client.GetAsync(url);

                //extraemos el token
                var responseString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);

                //anualamos el token caducado y alamcenamos el nuevo token en la cookie sin tener que reenviar al proceso de validación

                //1º extraemos el token nuevo
                responseData.TryGetValue("access_token", out var token);

                url = "https://localhost:5001/api/Usuarios";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                response = await client.GetAsync(url);

                responseString = await response.Content.ReadAsStringAsync();
                 List <CcaUser> ccaUsers = JsonConvert.DeserializeObject<List<CcaUser>>(responseString);
            }

            return new string[] { "value1", "value2" };
        }

        // GET: api/Home/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Home
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Home/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Home/5
        public void Delete(int id)
        {
        }


        public partial class CcaUser
        {
            public int IdUser { get; set; }

            public int IdRol { get; set; }

            public int IdSite { get; set; }

            public string Login { get; set; }

            public int VersionShow { get; set; }

            public string Email { get; set; }

            public int IdCalculationCycleType { get; set; }

        }
    }
}
