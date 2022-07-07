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
            TipoLancamento TipoLancamentoDB = ListarTipoPorCodigo(tipoLancamento.Codigo);
            if (TipoLancamentoDB == null) throw new SystemException("Ocorreu um erro na alteraçãol do tipo!");
            TipoLancamentoDB.Descricao = tipoLancamento.Descricao;
            _gerFinancasContext.TipoLancamento.Update(TipoLancamentoDB);
            _gerFinancasContext.SaveChanges();
            return TipoLancamentoDB;
        }
    }
}
