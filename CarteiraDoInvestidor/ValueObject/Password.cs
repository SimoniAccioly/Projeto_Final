using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Domain.ValueObject
{
    public class Password
    {
        public Password()
        {

        }
        public Password(string valor)
        {
            Valor = valor ?? throw new ArgumentNullException(nameof(Password));
        }

        public string Valor { get; set; }
    }
}
