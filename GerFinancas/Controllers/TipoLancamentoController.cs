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
            List<TipoLancamento> lista = _tipoLancamentoServicos.BuscarTodos();
            return View(lista);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int codigo)
        {
            TipoLancamento tipoLancamento = _tipoLancamentoServicos.ListarTipoPorCodigo(codigo);
            return View(tipoLancamento);
        }
        public IActionResult Apagar(int codigo)
        {
            TipoLancamento tipoLancamento = _tipoLancamentoServicos.ListarTipoPorCodigo(codigo);
            return View(tipoLancamento);
        }
        public IActionResult ApagarConfirma(int codigo)
        {
            _tipoLancamentoServicos.Apagar(codigo);
            return RedirectToAction("Index");
        }
        /*
        [HttpPost]
        public IActionResult Criar(TipoLancamento tipoLancamento)
        {
            _tipoLancamentoServicos.Adicionar(tipoLancamento);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Alterar(TipoLancamento tipoLancamento)
        {
            _tipoLancamentoServicos.Atualizar(tipoLancamento);
            return RedirectToAction("index");
        }*/
        [HttpPost]
        public IActionResult Salvar(TipoLancamento tipoLancamento)
        {
            if (tipoLancamento.Codigo == 0)
            {
                _tipoLancamentoServicos.Adicionar(tipoLancamento);
            }
            else
            {
                _tipoLancamentoServicos.Atualizar(tipoLancamento);
            }
            return RedirectToAction("index");
        }
    }
}
