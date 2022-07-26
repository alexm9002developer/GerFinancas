using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerFinancas.Models;

namespace GerFinancas.Acesso
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioLogin usuario);
        void RemoverSessaoDoUsuario();
        UsuarioLogin BuscarSessaoDoUsuario();

    }
}
