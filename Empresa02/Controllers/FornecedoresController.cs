using SistemaCadastro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SistemaCadastro.Controllers
{
    public class FornecedoresController : Controller
    {

        private static List<Fornecedores> _fornecedores = new List<Fornecedores>
        {
            new Fornecedores { Id = 1, NomeFornecedor = "ABRAP", CNPJ = "12.345.678/0001-95" },
            new Fornecedores { Id = 2, NomeFornecedor = "COBRA", CNPJ = "45.987.321/0001-09" },
            new Fornecedores { Id = 3, NomeFornecedor = "SNK", CNPJ = "60.123.987/0001-04" }
        };

        private static int _nextID = 4;
        public IActionResult Fornecedores()
        {
            return View(_fornecedores.OrderBy(a => a.Id).ToList());
        }

        [HttpGet]
        public IActionResult CriarFornecedor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarFornecedor(Fornecedores fornecedor)
        {
            if (!ModelState.IsValid)
                return View(fornecedor);

            fornecedor.Id = _nextID++;
            _fornecedores.Add(fornecedor);

            return RedirectToAction("Fornecedores");
        }

        [HttpGet]
        public IActionResult EditarFornecedor(int id)
        {
            var fornecedor = _fornecedores.FirstOrDefault(a => a.Id == id);

            if (fornecedor == null)
                return NotFound();

            return View(fornecedor);
        }

        [HttpPost]
        public IActionResult EditarFornecedor(Fornecedores fornecedor)
        {
            if (!ModelState.IsValid)
                return View(fornecedor);

            var existente = _fornecedores.FirstOrDefault(a => a.Id == fornecedor.Id);

            existente.NomeFornecedor = fornecedor.NomeFornecedor;
            existente.CNPJ = fornecedor.CNPJ;

            return RedirectToAction("Fornecedores");
        }

        public IActionResult ExcluirFornecedor(int id)
        {
            var fornecedor = _fornecedores.FirstOrDefault(a => a.Id == id);

            if (fornecedor == null)
                return NotFound();

            _fornecedores.Remove(fornecedor);

            return RedirectToAction("Fornecedores");
        }
        
    }
}
