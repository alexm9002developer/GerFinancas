using GerFinancas.Acesso;
using GerFinancas.Models;
using GerFinancas.Servico;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioLoginServicos _usuarioLoginServicos;
        private readonly ISessao _sessao;
        public AlterarSenhaController(IUsuarioLoginServicos usuarioLoginServicos, ISessao sessao)
        {
            _usuarioLoginServicos = usuarioLoginServicos;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Alterar(AlterarSenha alterarSenha)
        {
            try
            {
                UsuarioLogin usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                alterarSenha.Codigo = usuarioLogado.Codigo;
                if (ModelState.IsValid)
                {
                    
                    _usuarioLoginServicos.AlterarSenha(alterarSenha);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarSenha);
                }
                return View("Index", alterarSenha);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível alterar sua senha! Tente novamente, detalhe do erro: {erro.Message}";
                return View("Index", alterarSenha);
            }
        }
    }
}
