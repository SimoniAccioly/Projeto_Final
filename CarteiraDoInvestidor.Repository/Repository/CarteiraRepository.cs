using CarteiraDoInvestidor.Domain.Carteira.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Repository.Repository
{
    public class CarteiraRepository : RepositoryBase<Carteiras>
    {
        public CarteiraRepository(CarteiraDoInvestidorContext context) : base(context)
        {
        }
    }
}
