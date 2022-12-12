using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PoliciesAndClaims.Controllers
{
    
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();

        }

        public IActionResult Authenticate()
        {
            //en este metodo se define el login del aplicación

            //1º crear el usuario o endidad para la autentificación

            //si la cookie no existe pasara directamente por este método.
            //si ya existe omite este metodo.

            //Reclamos
            //Se define claims para indicar que una entidad puede responder por tí
            //Es decir que creamos una endidad para que pueda ser autentificada

            //en este caso nuestra abuela puede indetificarnos
            var grandmaClains = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Dani"),
                new Claim(ClaimTypes.Email, "Dani@gmail.com"),
                new Claim("Grandma.Says", "Dani es un buen chico")
            };


            //en este caso el departamento de trafico puede identificarnos
            var licenseClaims = new List<Claim>()
            { 
                new Claim(ClaimTypes.Name, "Daniel González"),
                new Claim("DrivingLicense", "B"),
            };

            var grandmaIdentity = new ClaimsIdentity(grandmaClains, "Grandma Identity");
            var licenseIdentity = new ClaimsIdentity(licenseClaims, "Government");

            var UserPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity, licenseIdentity });
            
            //implementas la autentificacion
            //2º accion login
            HttpContext.SignInAsync(UserPrincipal);

            return RedirectToAction("Index");

        }
    }
}
