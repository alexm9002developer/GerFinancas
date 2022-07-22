using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GerFinancas.Models;

namespace GerFinancas.Models
{
    public class Login
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informe o login!")]
        public string LoginUsuario { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a senha!")]
        public string Senha { get; set; }
    }
}
