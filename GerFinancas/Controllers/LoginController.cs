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
    public class LoginController : Controller
    {
        private readonly IUsuarioLoginServicos _usuarioLoginServicos;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioLoginServicos usuarioLoginServicos,
                               ISessao sessao)
        {
            _usuarioLoginServicos = usuarioLoginServicos;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            // Se o usuário estiver logado, redirecionar para a Home

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }
        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public IActionResult Entrar(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UsuarioLogin usuario = _usuarioLoginServicos.BuscarPorLogin(login.LoginUsuario);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(login.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha do usuário é inválida. Tente novamente.";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                }
                return View("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar seu login, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
