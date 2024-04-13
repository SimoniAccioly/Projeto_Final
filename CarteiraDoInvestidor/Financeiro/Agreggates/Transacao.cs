using CarteiraDoInvestidor.CrossCuting.Entity;
using CarteiraDoInvestidor.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Domain.Financeiro.Agreggates
{
    public class Transacao : Entity<Guid>
    {
        public object Transacoes;

        public DateTime DtTransacao { get; set; }
        public Monetario Valor { get; set; }
        public String Descricao { get; set; }
        public Merchant Merchant { get; set; }

    }
}
