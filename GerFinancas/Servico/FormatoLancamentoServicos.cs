using GerFinancas.Data;
using GerFinancas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Servico
{
    public class FormatoLancamentoServicos : IFormatoLancamentoServicos
    {
        private readonly GerFinancasContext _gerFinancasContext;
        public FormatoLancamentoServicos(GerFinancasContext gerFinancasContext)
        {
            this._gerFinancasContext = gerFinancasContext;
        }

        public FormatoLancamento Adicionar(FormatoLancamento formatoLancamento)
        {
            // Gravar no banco de dados
            _gerFinancasContext.FormatoLancamentos.Add(formatoLancamento);
            _gerFinancasContext.SaveChanges();
            return formatoLancamento;
        }
        public FormatoLancamento ListarFormatoPorCodigo(int codigo)
        {
            return _gerFinancasContext.FormatoLancamentos.FirstOrDefault(x => x.Codigo == codigo);
        }
        public List<FormatoLancamento> BuscarTodos()
        {
            return _gerFinancasContext.FormatoLancamentos.ToList();
        }
        public FormatoLancamento Atualizar(FormatoLancamento formatoLancamento)
        {
            // Gravar no banco de dados
            FormatoLancamento formatoLancamentoDB = ListarFormatoPorCodigo(formatoLancamento.Codigo);
            if (formatoLancamentoDB == null) throw new SystemException("Ocorreu um erro na operação!");
            formatoLancamentoDB.Descricao = formatoLancamento.Descricao;
            _gerFinancasContext.FormatoLancamentos.Update(formatoLancamentoDB);
            _gerFinancasContext.SaveChanges();
            return formatoLancamentoDB;
        }

        public bool Apagar(int codigo)
        {
            FormatoLancamento formatoLancamentoDB = ListarFormatoPorCodigo(codigo);
            if (formatoLancamentoDB == null) throw new SystemException("Ocorreu um erro na exclusão!");
            _gerFinancasContext.FormatoLancamentos.Remove(formatoLancamentoDB);
            _gerFinancasContext.SaveChanges();
            return true;
        }
    }
}
