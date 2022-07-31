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
        private readonly IEmail _email;
        public LoginController(IUsuarioLoginServicos usuarioLoginServicos, ISessao sessao, IEmail email)
        {
            _usuarioLoginServicos = usuarioLoginServicos;
            _sessao = sessao;
            _email = email;
        }
        public IActionResult Index()
        {
            // Se o usuário estiver logado, redirecionar para a Home

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }
        public IActionResult RedefinirSenha()
        {
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
                        TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Tente novamente.";
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
        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenha redefinirSenha)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UsuarioLogin usuario = _usuarioLoginServicos.BuscarPorEmailELogin(redefinirSenha.Email, redefinirSenha.LoginUsuario);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua senha temporária é: {novaSenha}";
                        bool emailEnviado = _email.Enviar(usuario.Email, "Gerencimento de Finanças - Nova Senha", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioLoginServicos.Atualizar(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para o seu e-mail cadastrado uma nova senha.";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não foi possível enviar o e-mail. Por favor, tente novamente.";
                        }
                        
                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MensagemErro"] = $"Não foi possível redefinir sua senha. Por favor, verifique os dados informados.";
                }
                return View("Index");

            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível redefinir sua senha, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
