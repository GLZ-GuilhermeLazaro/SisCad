using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SistemaCadastro.Models.Global;

namespace SistemaGlobal.Controllers.Global
{
    public class UsuarioController : Controller
    {

        private static List<Usuario> _Usuario = new List<Usuario>
        {
            new Usuario { Id = 1,NomeUsuario="Guilherme Lázaro",email = "glzin@icloud.com", senha = "123456**" },
            new Usuario { Id = 2,NomeUsuario="Luana Carvalho",email = "luna@hotmail.com", senha = "123456##" },
            new Usuario { Id = 3,NomeUsuario="Leonardo Calex",email = "lenox@gmail.com", senha = "123456" }
        };

        private static int _nextID = 4;
        public IActionResult Usuario()
        {
            return View("~/Views/Global/Usuario/Usuario.cshtml", _Usuario.OrderBy(a => a.Id).ToList());
        }

        [HttpGet]
        public IActionResult CriarUsuario()
        {
            return View("~/Views/Global/Usuario/CriarUsuario.cshtml");
        }

        [HttpPost]
        public IActionResult CriarUsuario(Usuario Usuario)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Global/Usuario/CriarUsuario.cshtml", Usuario);

            Usuario.Id = _nextID++;
            _Usuario.Add(Usuario);

            return RedirectToAction("Usuario");
        }

        [HttpGet]
        public IActionResult EditarUsuario(int id)
        {
            var Usuario = _Usuario.FirstOrDefault(a => a.Id == id);

            if (Usuario == null)
                return NotFound();

            return View("~/Views/Global/Usuario/EditarUsuario.cshtml", Usuario);
        }

        [HttpPost]
        public IActionResult EditarUsuario(Usuario Usuario)
        {
            if (!ModelState.IsValid)
                return View(Usuario);

            var existente = _Usuario.FirstOrDefault(a => a.Id == Usuario.Id);

            existente.email = Usuario.email;
            existente.senha = Usuario.senha;

            return RedirectToAction("Usuario");
        }

        public IActionResult ExcluirUsuario(int id)
        {
            var Usuario = _Usuario.FirstOrDefault(a => a.Id == id);

            if (Usuario == null)
                return NotFound();

            _Usuario.Remove(Usuario);

            return RedirectToAction("Usuario");
        }

    }
}
