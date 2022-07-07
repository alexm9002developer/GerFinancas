using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerFinancas.Models
{
    public class FormatoLancamento
    {
        [Key]
        [Display (Name = "Código")]
        public int Codigo { get; set; }

        [Display (Name = "Descrição")]
        [Required (ErrorMessage = "Informe a descrição")]
        public string Descricao { get; set; }

        public FormatoLancamento()
        {

        }

        public FormatoLancamento(int codigo, string descricao)
        {
            this.Codigo = codigo;
            this.Descricao = descricao;
        }
    }
}
