using CarteiraDoInvestidor.CrossCuting.Entity;
using CarteiraDoInvestidor.Domain.Conta.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Domain.Carteira.Agreggates
{
    public class Carteiras : Entity<Guid>
    {
        public string NomeCarteira { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public virtual Guid UsuarioId { get; set; }
        public virtual List<Ativos> ListaDeAtivos { get; set; } = new List<Ativos>();

        public int QuantidadeAtivos()
            => this.ListaDeAtivos.Count;

    }
}

