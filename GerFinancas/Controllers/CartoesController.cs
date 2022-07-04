using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerFinancas.Models;
using GerFinancas.Servico;

namespace GerFinancas.Controllers
{
    public class CartoesController : Controller
    {
        private readonly ICartoesServicos _cartoesServicos;
        public CartoesController(ICartoesServicos cartoesServicos)
        {
            _cartoesServicos = cartoesServicos;
        }
        public IActionResult Index()
        {
            List<Cartoes> lista = _cartoesServicos.BuscarTodos();
            return View(lista);
        }

        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Alterar(int codigo)
        {
            Cartoes cartoes = _cartoesServicos.ListarPorCodigo(codigo);
            return View(cartoes);
        }
        public IActionResult ApagarConfirma(int codigo)
        {
            _cartoesServicos.Apagar(codigo);
            return RedirectToAction("index");
        }
        public IActionResult Apagar(int codigo)
        {
            Cartoes cartoes = _cartoesServicos.ListarPorCodigo(codigo);
            return View(cartoes);
        }

        [HttpPost]
        public IActionResult Criar(Cartoes cartoes)
        {
            _cartoesServicos.Adicionar(cartoes);
            return RedirectToAction("index");
        }
        [HttpPost]
        public IActionResult Alterar(Cartoes cartoes)
        {
            _cartoesServicos.Atualizar(cartoes);
            return RedirectToAction("index");
        }
    }
}
