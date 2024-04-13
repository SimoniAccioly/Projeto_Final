using CarteiraDoInvestidor.CrossCuting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Domain.Financeiro.Agreggates
{
    public class Assinatura : Entity<Guid>
    {
        public virtual Plano? Plano { get; set; }
        public bool Ativo { get; set; }
        public DateTime DtAtivacao { get; set; }
    }
}
