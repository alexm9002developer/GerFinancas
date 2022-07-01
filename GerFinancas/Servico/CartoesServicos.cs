using GerFinancas.Data;
using GerFinancas.Models;
using GerFinancas.Models.ViewModels;
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
        public Cartoes ListarPorCodigo(int codigo)
        {
            return _gerFinancasContext.Cartoes.FirstOrDefault(x => x.Codigo == codigo);
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

        public Cartoes Atualizar(Cartoes cartoes)
        {
            // Gravar no bando de dados
            Cartoes CartaoDB = ListarPorCodigo(cartoes.Codigo);
            if (CartaoDB == null) throw new SystemException("Ocorreu um erro na alteração do cartão!");
            CartaoDB.Descricao = cartoes.Descricao;
            CartaoDB.DiaVencimento = cartoes.DiaVencimento;
            CartaoDB.MelhorDiaCompra = cartoes.MelhorDiaCompra;
            _gerFinancasContext.Cartoes.Update(CartaoDB);
            _gerFinancasContext.SaveChanges();
            return CartaoDB;
        }
    }
}
