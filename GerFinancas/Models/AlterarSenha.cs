using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Models
{
    public class AlterarSenha
    {
        public int Codigo { get; set; }
        
        [Display(Name = "Senha Atual")]
        [Required(ErrorMessage = "Informe a senha atual do usuário!")]
        public string SenhaAtual { get; set; }

        [Display(Name = "Nova Senha")]
        [Required(ErrorMessage = "Informe a nova senha!")]
        public string NovaSenha { get; set; }

        [Display(Name = "Confirmar nova Senha")]
        [Required(ErrorMessage = "Confirme a nova senha!")]
        [Compare("NovaSenha", ErrorMessage = "Senha não confere com a nova senha")]
        public string ConfirmarNovaSenha { get; set; }
    }
}
