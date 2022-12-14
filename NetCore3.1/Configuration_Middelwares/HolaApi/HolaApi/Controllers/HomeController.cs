using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            Usuario usuario = new Usuario();
            usuario.Id = 1;
            usuario.Name = "dani";
            usuario.email = "daniel@daniel.com";

            return usuario.Name;

        }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email{ get; set; }
    }
}


