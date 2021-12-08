using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using OnePiece.Models;

namespace OnePiece.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(onepieceContext context)
        {
            Context = context;
        }

        public onepieceContext Context { get; }

        [Route("Account/Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("Account/Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var hash = Helpers.Cifrado.GetHash(password);
            var user = Context.Usuarios.SingleOrDefault(x => x.NombreUsuario == username && x.Password == hash);
            if (user != null)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.NombreReal));
                claims.Add(new Claim(ClaimTypes.Role, user.Rol));
                claims.Add(new Claim("Id", user.Id.ToString()));

                var identidad = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(new ClaimsPrincipal(identidad));

                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                ModelState.AddModelError("", "Usuario o Contraseña incorrectos");
                return View();
            }

        }
        [Route("Account/Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
            
        }

        [Route("Account/AccessDenied")]
        public string AccessDenied()
        {
           
            return "No puedes acceder a este sitio, acceso denegado";

        }
    }
}
