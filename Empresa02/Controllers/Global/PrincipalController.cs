using Microsoft.AspNetCore.Mvc;

namespace SistemaCadastro.Controllers.Global
{
    public class PrincipalController : Controller
    {
        public IActionResult Principal()
        {
            return View("~/Views/Global/Principal.cshtml");
        }
    }
}
