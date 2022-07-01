using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using GerFinancas.Models;
using GerFinancas.Models.Enums;

namespace GerFinancas.Models
{
    public class Lancamentos
    {
        [Key]
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Display(Name = "Tipo de Lançamento")]
        [Required(ErrorMessage = "Selecione o tipo de Lançamento!")]
        public ReceitaDespesa ReceitaDespesa { get; set; }

        [Display(Name = "Formato de Pagamento")]
        [Required(ErrorMessage = "Informe o formato de pagamento!")]
        public int TipoDoLancamento { get; set; }

        [Required(ErrorMessage = "Informe o valor do lançamento!")]
        public double Valor { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe descrição!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a data de Vencimento!")]
        [Display(Name = "Data de Vencimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Vencimento { get; set; }
        public DateTime DataLancamento { get; set; }
        public TipoLancamento Tipo { get; set; }
        public int TipoCodigo { get; set; }

        public Lancamentos()
        {

        }
        public Lancamentos(int codigo, ReceitaDespesa receitaDespesa, int tipoDoLancamento, double valor, string descricao, DateTime vencimento, DateTime dataLancamento, TipoLancamento tipo)
        {
            this.Codigo = codigo;
            this.ReceitaDespesa = receitaDespesa;
            this.TipoDoLancamento = tipoDoLancamento;
            this.Valor = valor;
            this.Descricao = descricao;
            this.Vencimento = vencimento;
            this.DataLancamento = dataLancamento;
            this.Tipo = tipo;
        }
    }
}
