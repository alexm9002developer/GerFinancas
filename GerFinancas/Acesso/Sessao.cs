using GerFinancas.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Acesso
{
    public class Sessao : ISessao
    {

        private readonly IHttpContextAccessor _IHttpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _IHttpContext = httpContext;
        }
        public UsuarioLogin BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _IHttpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            return JsonConvert.DeserializeObject<UsuarioLogin>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(UsuarioLogin usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _IHttpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoDoUsuario()
        {
            _IHttpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
