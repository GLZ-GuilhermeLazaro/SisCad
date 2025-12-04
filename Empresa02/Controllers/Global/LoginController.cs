using Microsoft.AspNetCore.Mvc;
using SistemaCadastro.Models.Global;
using System.Globalization;

namespace SistemaCadastro.Controllers
{
    public class LoginController : Controller
    {

        private static List<Usuario> _usuarios = new List<Usuario>
        {
           new Usuario { Id = 1,NomeUsuario="Guilherme Lázaro",email = "glzin@icloud.com", senha = "123456**" },
            new Usuario { Id = 2,NomeUsuario="Luana Carvalho",email = "luna@hotmail.com", senha = "123456##" },
            new Usuario { Id = 3,NomeUsuario="Leonardo Calex",email = "lenox@gmail.com", senha = "123456" }
        };

        [HttpGet]
        public IActionResult Principal()
        {
            return View("~/Views/Global/Principal.cshtml");
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            var usuarioEncontrado = _usuarios
                .FirstOrDefault(u => u.email == usuario.email && u.senha == usuario.senha);

            if (usuarioEncontrado != null)
            {
                return RedirectToAction("Principal");
            }

            ViewBag.Erro = "Usuario ou senha invalidos";
            return View(usuario);
        }
    }
}
