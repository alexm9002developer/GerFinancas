using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Models
{
    public class RedefinirSenha
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informe o login!")]
        public string LoginUsuario { get; set; }

        [Display(Name = "e-mail")]
        [Required(ErrorMessage = "Informe o e-mail!")]
        public string Email { get; set; }
    }
}
