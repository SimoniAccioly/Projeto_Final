using CarteiraDoInvestidor.Domain.Conta.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Repository.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public CarteiraDoInvestidorContext Context { get; set; }

        public UsuarioRepository(CarteiraDoInvestidorContext context) : base(context)
        {
            Context = context;
        }
    }
}
