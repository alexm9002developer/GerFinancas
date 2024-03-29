﻿using GerFinancas.Models;
using GerFinancas.Servico;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerFinancas.Controllers;
using GerFinancas.Filters;

namespace GerFinancas.Controllers
{
    [PaginaParaUsuarioLogado]
    public class FormatoLancamentoController : Controller
    {
        private readonly IFormatoLancamentoServicos _formatoLancamentoServicos;
        public FormatoLancamentoController(IFormatoLancamentoServicos formatoLancamentoServicos)
        {
            _formatoLancamentoServicos = formatoLancamentoServicos;
        }
        public IActionResult Index()
        {
            List<FormatoLancamento> lista = _formatoLancamentoServicos.BuscarTodos();
            return View(lista);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int codigo)
        {
            FormatoLancamento formatoLancamento = _formatoLancamentoServicos.ListarFormatoPorCodigo(codigo);
            return View(formatoLancamento);
        }
        public IActionResult Apagar(int codigo)
        {
            FormatoLancamento formatoLancamento = _formatoLancamentoServicos.ListarFormatoPorCodigo(codigo);
            return View(formatoLancamento);
        }
        public IActionResult ApagarConfirma(int codigo)
        {
            _formatoLancamentoServicos.Apagar(codigo);
            TempData["MensagemSucesso"] = "Formato de Lançamento excluído com sucesso!";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Salvar(FormatoLancamento formatoLancamento)
        {
            if (formatoLancamento.Codigo == 0)
            {
                _formatoLancamentoServicos.Adicionar(formatoLancamento);
                TempData["MensagemSucesso"] = "Formato de Lançamento cadastrado com sucesso!";
            }
            else
            {
                _formatoLancamentoServicos.Atualizar(formatoLancamento);
                TempData["MensagemSucesso"] = "Formato de Lançamento alterado com sucesso!";
            }
            return RedirectToAction("Index");
        }
    }
}
