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

        /*[HttpPost]
        public IActionResult Salvar(Cartoes cartoes)
        {
            if (ModelState.IsValid)
            {
                _cartoesServicos.Adicionar(cartoes);
                return RedirectToAction("Index");
            }
            return View(cartoes);
        }*/

        [HttpPost]
        public IActionResult Salvar(Cartoes cartoes)
        {
            try
            {
                if (cartoes.Codigo == 0)
                {
                    _cartoesServicos.Adicionar(cartoes);
                    TempData["MensagemSucesso"] = "Cartão cadastrado com sucesso";
                }
                else
                {
                    _cartoesServicos.Atualizar(cartoes);
                }
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro. Cartão não cadastrado. Tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("index");
            }
        }


        [HttpPost]
        public IActionResult Alterar(Cartoes cartoes)
        {
            _cartoesServicos.Atualizar(cartoes);
            return RedirectToAction("index");
        }
    }
}
