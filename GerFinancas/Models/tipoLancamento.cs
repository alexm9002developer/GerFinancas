using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GerFinancas.Models
{
    public class TipoLancamento
    {
        [Key]
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe a descrição!")]
        public string Descricao { get; set; }

        public TipoLancamento()
        {

        }

        public TipoLancamento(int codigo, string descricao)
        {
            this.Codigo = codigo;
            this.Descricao = descricao;
        }
    }
}
