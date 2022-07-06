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
            _gerFinancasContext = gerFinancasContext;
        }
        public TipoLancamento Adicionar(TipoLancamento tipoLancamento)
        {
            // Gravar no banco de dados
            _gerFinancasContext.TipoLancamento.Add(tipoLancamento);
            _gerFinancasContext.SaveChanges();
            return tipoLancamento;
        }
    }
}
