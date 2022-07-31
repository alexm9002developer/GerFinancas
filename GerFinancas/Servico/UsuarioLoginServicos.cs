using GerFinancas.Data;
using GerFinancas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Servico
{
    public class UsuarioLoginServicos : IUsuarioLoginServicos
    {
        private readonly GerFinancasContext _gerFinancasContext;
        public UsuarioLoginServicos(GerFinancasContext gerFinancasContext)
        {
            this._gerFinancasContext = gerFinancasContext;
        }
        public UsuarioLogin Adicionar(UsuarioLogin usuarioLogin)
        {
            // Gravar no banco de dados
            usuarioLogin.DataCadastro = DateTime.Now;
            usuarioLogin.DataAlteracao = DateTime.Now;
            usuarioLogin.SetSenhaHash();
            _gerFinancasContext.UsuarioLogin.Add(usuarioLogin);
            _gerFinancasContext.SaveChanges();
            return usuarioLogin;
        }

        public UsuarioLogin BuscarPorLogin(string login)
        {
            return _gerFinancasContext.UsuarioLogin.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }
        public bool AutenticaUsuario(string Login, string Senha)
        {
            UsuarioLogin usuario = BuscarPorLogin(Login);
            return (usuario.Senha == Senha);
        }

        public UsuarioLogin BuscarPorEmailELogin(string email, string login)
        {
            return _gerFinancasContext.UsuarioLogin.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioLogin ListarUsuarioPorCodigo(int codigo)
        {
            return _gerFinancasContext.UsuarioLogin.FirstOrDefault(x => x.Codigo == codigo);
        }

        public List<UsuarioLogin> BuscarTodos()
        {
            return _gerFinancasContext.UsuarioLogin.ToList();
        }

        public UsuarioLogin Atualizar(UsuarioLogin usuarioLogin)
        {
            // Gravar no banco de dados
            UsuarioLogin usuarioLoginDB = ListarUsuarioPorCodigo(usuarioLogin.Codigo);
            if (usuarioLoginDB == null) throw new SystemException("Ocorreu um erro na operação!");
            usuarioLoginDB.Nome = usuarioLogin.Nome;
            usuarioLoginDB.Login = usuarioLogin.Login;
            usuarioLoginDB.Email = usuarioLogin.Email;
            //usuarioLoginDB.Senha = usuarioLogin.Senha;
            usuarioLoginDB.Perfil = usuarioLogin.Perfil;
            usuarioLoginDB.DataAlteracao = DateTime.Now;
            _gerFinancasContext.UsuarioLogin.Update(usuarioLoginDB);
            _gerFinancasContext.SaveChanges();
            return usuarioLoginDB;
        }

        public UsuarioLogin AlterarSenha(AlterarSenha alterarSenha)
        {
            UsuarioLogin usuarioDB = ListarUsuarioPorCodigo(alterarSenha.Codigo);
            if (usuarioDB == null) throw new Exception("Houve um erro na atualização da Senha, usuário não encontrado!");
            if (!usuarioDB.SenhaValida(alterarSenha.SenhaAtual)) throw new Exception("Senha atual não confere!");
            if (usuarioDB.SenhaValida(alterarSenha.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual!");
            usuarioDB.SetNovaSenha(alterarSenha.NovaSenha);
            usuarioDB.DataAlteracao = DateTime.Now;
            _gerFinancasContext.UsuarioLogin.Update(usuarioDB);
            _gerFinancasContext.SaveChanges();
            return usuarioDB;
        }

        public bool Apagar(int codigo)
        {
            UsuarioLogin usuarioLoginDB = ListarUsuarioPorCodigo(codigo);
            if (usuarioLoginDB == null) throw new SystemException("Ocorreu um erro na exclusão!");
            _gerFinancasContext.UsuarioLogin.Remove(usuarioLoginDB);
            _gerFinancasContext.SaveChanges();
            return true;
        }
    }
}
