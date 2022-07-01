using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerFinancas.Models;

namespace GerFinancas.Controllers
{
    public class TipoLancamentoController : Controller
    {
        public IActionResult Index()
        {
            List<TipoLancamento> lista = new List<TipoLancamento>();

            lista.Add(new TipoLancamento() { Codigo = 1, Descricao = "Fixo" });
            lista.Add(new TipoLancamento() { Codigo = 2, Descricao = "Variável" });

            return View(lista);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult Apagar()
        {
            return View();
        }
    }
}
