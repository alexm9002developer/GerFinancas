using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerFinancas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GerFinancas.ViewComponentes
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            UsuarioLogin usuario = JsonConvert.DeserializeObject<UsuarioLogin>(sessaoUsuario);
            return View(usuario);
        }
    }
}
