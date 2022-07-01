using GerFinancas.Data;
using GerFinancas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Servico
{
    public class CartoesServico : ICartoesServicos
    {
        private readonly GerFinancasContext _gerFinancasContext;
        public CartoesServico(GerFinancasContext gerFinancasContext)
        {
            _gerFinancasContext = gerFinancasContext;
        }
        public List<Cartoes> BuscarTodos()
        {
            return _gerFinancasContext.Cartoes.ToList();
        }
        public Cartoes Adicionar(Cartoes cartoes)
        {
            // Gravar no bando de dados
            _gerFinancasContext.Cartoes.Add(cartoes);
            _gerFinancasContext.SaveChanges();
            return cartoes;
        }  
    }
}
