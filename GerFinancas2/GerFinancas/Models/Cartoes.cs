using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GerFinancas.Models
{
    public class Cartoes
    {
        [Key]
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe a descrição do cartão!")]
        public String Descricao { get; set; }

        [Required(ErrorMessage = "Informe o limite do cartão!")]
        public double Limite { get; set; }

        [Display(Name = "Dia do Vencimento")]
        [Required(ErrorMessage = "Informe o dia de Vencimento!")]
        public int DiaVencimento { get; set; }

        [Display(Name = "Melhor dia para compra")]
        [Required(ErrorMessage = "Informe o melhor dia para compra!")]
        public int MelhorDiaCompra { get; set; }

        public Cartoes()
        {

        }

        public Cartoes(int codigo, string descricao, double limite, int diaVencimento, int melhorDiaCompra)
        {
            this.Codigo = codigo;
            this.Descricao = descricao;
            this.Limite = limite;
            this.DiaVencimento = diaVencimento;
            this.MelhorDiaCompra = melhorDiaCompra;
        }
    }
}
