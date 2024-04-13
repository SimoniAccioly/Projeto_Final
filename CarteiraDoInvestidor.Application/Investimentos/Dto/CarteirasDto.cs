using CarteiraDoInvestidor.Domain.Conta.Agreggates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Application.Investimentos.Dto
{
    public class CarteirasDto
    {
        public Guid Id { get; set; }

        [Required]
        public Guid CarteiraId { get; set; }

        [Required]
        public string NomeCarteira { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        [Required]
        public virtual Usuario Usuario { get; set; }

        public List<AtivosDto> Ativos { get; set; } = new List<AtivosDto>();
    }
}
