using GerFinancas.Data;
using GerFinancas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Servico
{
    public class TipoLancamentoServicos : ITipoLancamentoServicos
    {
        private readonly GerFinancasContext _gerFinancasContext;
        public TipoLancamentoServicos(GerFinancasContext gerFinancasContext)
        {
            this._gerFinancasContext = gerFinancasContext;
        }
        public TipoLancamento Adicionar(TipoLancamento tipoLancamento)
        {
            // Gravar no banco de dados
            _gerFinancasContext.TipoLancamento.Add(tipoLancamento);
            _gerFinancasContext.SaveChanges();
            return tipoLancamento;
        }
        public TipoLancamento ListarTipoPorCodigo(int codigo)
        {
           return _gerFinancasContext.TipoLancamento.FirstOrDefault(x => x.Codigo == codigo);
        }

        public List<TipoLancamento> BuscarTodos()
        {
            return _gerFinancasContext.TipoLancamento.ToList();
        }

        public TipoLancamento Atualizar(TipoLancamento tipoLancamento)
        {
            // Gravar no banco de dados
            TipoLancamento tipoLancamentoDB = ListarTipoPorCodigo(tipoLancamento.Codigo);
            if (tipoLancamentoDB == null) throw new SystemException("Ocorreu um erro na operação!");
            tipoLancamentoDB.Descricao = tipoLancamento.Descricao;
            _gerFinancasContext.TipoLancamento.Update(tipoLancamentoDB);
            _gerFinancasContext.SaveChanges();
            return tipoLancamentoDB;
        }

        public bool Apagar(int codigo)
        {
            TipoLancamento tipoLancamentoDB = ListarTipoPorCodigo(codigo);
            if (tipoLancamentoDB == null) throw new SystemException("Ocorreu um erro na exclusão!");
            _gerFinancasContext.TipoLancamento.Remove(tipoLancamentoDB);
            _gerFinancasContext.SaveChanges();
            return true;
        }
    }
}
