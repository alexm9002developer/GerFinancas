using GerFinancas.Models;
using GerFinancas.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Servico
{
    public interface ICartoesServicos
    {
        Cartoes ListarPorCodigo(int codigo);
        List<Cartoes> BuscarTodos();
        Cartoes Adicionar(Cartoes cartoes);
        Cartoes Atualizar(Cartoes cartoes);
    }
}
