using CarteiraDoInvestidor.Domain.Carteira.Agreggates;
using CarteiraDoInvestidor.Domain.Conta.Agreggates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Application.Investimentos.Dto
{
    public class AtivosDto
    {
        public Guid Id { get; set; }

        [Required]
        public string Papel { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public double PrecoMedio { get; set; }

        [Required]
        public string Corretora { get; set; }

        public double TaxaDeCorretagem { get; set; }

        [Required]
        public DateTime DataDaCompra { get; set; }

        [Required]
        public string LadoDaOperacao { get; set; }


    }
}
