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
        [HttpPost]
        public IActionResult Salvar(UsuarioLogin usuarioLogin)
        {
            if (usuarioLogin.Codigo == 0)
            {
                _usuarioLoginServicos.Adicionar(usuarioLogin);
            }
            else
            {
                _usuarioLoginServicos.Atualizar(usuarioLogin);
            }
            return RedirectToAction("Index");
        }
    }
}
