using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityExample.Controlllers
{
    
    public class HomeController : Controller
    {
        
        
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signiInManager;

        //clase q contiene toda la informacin del usuario ( quien lo creó, contraseña, nombre. ect)
        public HomeController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signiInManager)
            
        {
            _userManager = userManager;
            _signiInManager = signiInManager;
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
                var signInResult = await _signiInManager.PasswordSignInAsync(user, password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> LogOut()
        {
            //elimina la cookie creada
            await _signiInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
