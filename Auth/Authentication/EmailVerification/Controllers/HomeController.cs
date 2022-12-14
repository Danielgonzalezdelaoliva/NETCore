using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmailVerification.Controlllers
{
    /// <summary>
    /// En lineas generales el proceso confirma que la dirección de correo sea correcta y envia un correo a esa direccion
    /// para que confirme el proceso. Una vez confirmado solicita el login y redireccionada a la pagina principal. Posteriormente
    /// con la autentifación correcta podemos acceder al endpoint Secret
    /// La dirección de correo se obtiene del archivo appsettings.json
    /// </summary>
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signiInManager;
        private readonly IEmailService _emailService;

        //clase q contiene toda la informacin del usuario ( quien lo creó, contraseña, nombre. ect)
        public HomeController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signiInManager,
            IEmailService emailService)
            
        {
            _userManager = userManager;
            _signiInManager = signiInManager;
            _emailService = emailService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();

        }

        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                var signInResult = await _signiInManager.PasswordSignInAsync(user, password, false, false);

                if(signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            var user = new IdentityUser
            {
                UserName = username,
                Email = "",
            };

            //esta es la parte de la creación del usuario en la base de datos
            var result = await _userManager.CreateAsync(user, password);

            //esta es la parte de la login del usuario
            if (result.Succeeded)
            {
                //generation del token de confirmacion de email
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                //posterior al login debemos enviar un link para que confirme la dirección de email.
                var link = Url.Action(nameof(VerifyEmail),"Home", new { UserId = user.Id, code}, Request.Scheme , Request.Host.ToString());

                await _emailService.SendAsync("test@test.com", "email verify", $"<a href =\"{link}\">Verify Email</a>",true);

                return RedirectToAction("EmailVerification");

            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> VerifyEmail(string  userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest();

            var result = await _userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return View();
            }

            //no especificar nunca el motivo del error. Para no mostar más información de la necesaria.
            return BadRequest();

        }

        public IActionResult EmailVerification() => View();

        public async Task<IActionResult> LogOut()
        {
            //elimina la cookie creada
            await _signiInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
