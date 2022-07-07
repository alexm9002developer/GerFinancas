using GerFinancas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Servico
{
    public interface IFormatoLancamentoServicos
    {
        FormatoLancamento ListarFormatoPorCodigo(int Codigo);
        List<FormatoLancamento> BuscarTodos();
        FormatoLancamento Adicionar(FormatoLancamento formatoLancamento);
        FormatoLancamento Atualizar(FormatoLancamento formatoLancamento);
        bool Apagar(int codigo);
    }
}
