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
            /*List<Cartoes> lista = new List<Cartoes>();

            lista.Add(new Cartoes() { Codigo = 1, Descricao = "Nubank Mastercard", DiaVencimento = 10, Limite = 5000, MelhorDiaCompra = 01 });
            lista.Add(new Cartoes() { Codigo = 2, Descricao = "Santander Visa Black", DiaVencimento = 15, Limite = 15000, MelhorDiaCompra = 05 });
            lista.Add(new Cartoes() { Codigo = 3, Descricao = "C6 Visa", DiaVencimento = 20, Limite = 3000, MelhorDiaCompra = 10 });
            lista.Add(new Cartoes() { Codigo = 4, Descricao = "American Express", DiaVencimento = 20, Limite = 25000, MelhorDiaCompra = 10 });
            */

            List<Cartoes> lista = _cartoesServicos.BuscarTodos();
            return View(lista);
        }

        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult Apagar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Cartoes cartoes)
        {
            _cartoesServicos.Adicionar(cartoes);
            return RedirectToAction("index");
        }
    }
}
