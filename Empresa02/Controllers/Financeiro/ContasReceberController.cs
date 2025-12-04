using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using SistemaCadastro.Models.Financeiro;

namespace SistemaCadastro.Controllers.Financeiro
{
    public class ContasReceberController : Controller
    {
        //Metodo para simular a busca de dados de alunos no BD
        private List<ContasReceber> ObterContasReceber()
        {
            var listaDeContasReceber = new List<ContasReceber>
            {
                new ContasReceber { ContaID = 1, ValorConta = 1000, ValorRecebido = 500 },
                new ContasReceber { ContaID = 2, ValorConta = 2500, ValorRecebido = 2500 },
                new ContasReceber { ContaID = 3, ValorConta = 500, ValorRecebido = 500 }
            };
            return listaDeContasReceber.OrderBy(a => a.ContaID).ToList();
        }
        public IActionResult ContasReceber()
        {
            var contasreceber = ObterContasReceber();
            return View("~/Views/Financeiro/ContasReceber/ContasReceber.cshtml", contasreceber);
        }
    }
}
