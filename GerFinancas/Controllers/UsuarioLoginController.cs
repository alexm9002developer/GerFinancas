﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Controllers
{
    public class UsuarioLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}