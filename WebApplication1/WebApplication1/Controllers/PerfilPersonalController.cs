using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilPersonalController : ControllerBase
    {
        //[HttpGet("LeerPerfil/{id}")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return id switch
            {
                1 => "Daniel",
                2 => "Curso",
                _ => throw new NotSupportedException("el id no es válido")
            };
        }

        [HttpGet]
        public string Get()
        {
            return "1";
        }

        [HttpPost]       
        public string Post(PerfilPersonalDto perfilPersonal)
        {

            return perfilPersonal.Apellido;
        }
    }

    public class PerfilPersonalDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
    }
}

