using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarteiraDoInvestidor.CrossCuting.Entity;
using CarteiraDoInvestidor.Domain.ValueObject;

namespace CarteiraDoInvestidor.Domain.Financeiro.Agreggates
{
    public class Plano : Entity<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Monetario Valor { get; set; }

    }
}
