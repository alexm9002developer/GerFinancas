using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Models
{
    public class Login
    {
        public int Id { get; set; }
        private string Usuario { get; set; }
        private string Senha { get; set; }

        public Login()
        {

        }
        public Login(string usuario, string senha)
        {
            this.Usuario = usuario;
            this.Senha = senha;
        }
    }
}
