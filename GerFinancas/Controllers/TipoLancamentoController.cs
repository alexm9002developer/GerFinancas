using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerFinancas.Models;
using GerFinancas.Servico;
using GerFinancas.Controllers;


namespace GerFinancas.Controllers
{
    public class TipoLancamentoController : Controller
    {
        private readonly ITipoLancamentoServicos _tipoLancamentoServicos;
        public TipoLancamentoController(ITipoLancamentoServicos tipoLancamentoServicos)
        {
            _tipoLancamentoServicos = tipoLancamentoServicos;
        }
        public IActionResult Index()
        {
            return View();
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
        [HttpPost]
        public IActionResult Criar(TipoLancamento tipoLancamento)
        {
            _tipoLancamentoServicos.Adicionar(tipoLancamento);
            return RedirectToAction("Index");
        }
    }
}
