﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerFinancas.Models;
using GerFinancas.Servico;
using GerFinancas.Controllers;
using GerFinancas.Filters;

namespace GerFinancas.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioLoginController : Controller
    {
        private readonly IUsuarioLoginServicos _usuarioLoginServicos;
        public UsuarioLoginController(IUsuarioLoginServicos usuarioLoginServicos)
        {
            _usuarioLoginServicos = usuarioLoginServicos;
        }
        public IActionResult Index()
        {
            List<UsuarioLogin> lista = _usuarioLoginServicos.BuscarTodos();
            return View(lista);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int codigo)
        {
            UsuarioLogin usuarioLogin = _usuarioLoginServicos.ListarUsuarioPorCodigo(codigo);
            return View(usuarioLogin);
        }
        [HttpPost]
        public IActionResult Salvar(UsuarioLogin usuarioLogin)
        {
            if (usuarioLogin.Codigo == 0)
            {
                _usuarioLoginServicos.Adicionar(usuarioLogin);
                TempData["MensagemSucesso"] = "Usuário adicionado com sucesso!";
            }
            else
            {
                _usuarioLoginServicos.Atualizar(usuarioLogin);
                TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
            }
            return RedirectToAction("Index");
        }
        public IActionResult Apagar(int codigo)
        {
            UsuarioLogin usuarioLogin = _usuarioLoginServicos.ListarUsuarioPorCodigo(codigo);
            return View(usuarioLogin);
        }
        public IActionResult ApagarConfirma(int codigo)
        {
            _usuarioLoginServicos.Apagar(codigo);
            TempData["MensagemSucesso"] = "Usuário excluído com sucesso!";
            return RedirectToAction("Index");
        }
    }
}
