using GerFinancas.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Models
{
    public class UsuarioLogin
    {
        [Key]
        public int Codigo { get; set; }

        [Display(Name = "Nome Usuário")]
        [Required(ErrorMessage = "Informe o nome do usuário!")]
        public string Nome { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informe o login do usuário!")]
        public string Login { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Informe o email do usuário!")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a senha do usuário!")]
        public string Senha { get; set; }

        public PerfilEnum Perfil { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public UsuarioLogin()
        {

        }

        public UsuarioLogin(int codigo, 
            string nome, 
            string login, 
            string email, 
            string senha, 
            PerfilEnum perfil, 
            DateTime dataCadastro, 
            DateTime? dataAlteracao)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Login = login;
            this.Email = email;
            this.Senha = senha;
            this.Perfil = perfil;
            this.DataCadastro = dataCadastro;
            this.DataAlteracao = dataAlteracao;
        }
    }
}
