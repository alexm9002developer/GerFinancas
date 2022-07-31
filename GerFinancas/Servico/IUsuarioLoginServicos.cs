using GerFinancas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Servico
{
    public interface IUsuarioLoginServicos
    {
        UsuarioLogin BuscarPorLogin(string Login);
        UsuarioLogin BuscarPorEmailELogin(string email, string login);
        UsuarioLogin ListarUsuarioPorCodigo(int Codigo);
        List<UsuarioLogin> BuscarTodos();
        UsuarioLogin Adicionar(UsuarioLogin usuarioLogin);
        UsuarioLogin Atualizar(UsuarioLogin usuarioLogin);
        UsuarioLogin AlterarSenha(AlterarSenha alterarSenha);
        bool Apagar(int codigo);
    }
}
