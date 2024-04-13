using CarteiraDoInvestidor.Domain.Financeiro.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Repository.Repository
{
    public class PlanoRepository : RepositoryBase<Plano>
    {
        public CarteiraDoInvestidorContext Context { get; set; }

        public PlanoRepository(CarteiraDoInvestidorContext context) : base(context)
        {
            Context = context;
        }


    }
}
