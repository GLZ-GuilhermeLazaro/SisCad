using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaCadastro.Models;

namespace SistemaCadastro.Controllers
{
    public class ContasPagarController : Controller
    {
        //Metodo para simular a busca de dados de alunos no BD
        private List<ContasPagar> ObterContasPagar()
        {
            var listaDeContasPagar = new List<ContasPagar>
            {
                new ContasPagar { ContaID = 1, ValorConta = 1000, ValorPago = 500 },
                new ContasPagar { ContaID = 2, ValorConta = 2500, ValorPago = 2500 },
                new ContasPagar { ContaID = 3, ValorConta = 500, ValorPago = 500 }
            };
            return listaDeContasPagar.OrderBy(a => a.ContaID).ToList();
        }
        public IActionResult ContasPagar()
        {
            var contaspagar = ObterContasPagar();
            return View(contaspagar);
        }
    }
}
