using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Application.Conta.Dto
{
    public class CartaoDto
    {
        public Guid Id { get; set; }
        public Boolean Ativo { get; set; }
        public String Numero { get; set; }
        public DateTime Validade { get; set; }
        public int CVV { get; set; }
        public Decimal Limite { get; set; }
    }
}
