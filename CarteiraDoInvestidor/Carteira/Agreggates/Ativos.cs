using CarteiraDoInvestidor.CrossCuting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Domain.Carteira.Agreggates
{
    public class Ativos : Entity<Guid>
    {
        public string Papel { get; set; }
        public int Quantidade { get; set; }
        public double PrecoMedio { get; set; }
        public string Corretora { get; set; }
        public double TaxaDeCorretagem { get; set; }
        public DateTime DataDaCompra { get; set; }
        public string LadoDaOperacao { get; set; }
        public virtual IList<Carteiras> Carteiras { get; set; } = new List<Carteiras>();


        public class AtivosManager
        {
            private List<Ativos> listaDeAtivos;

            public AtivosManager()
            {
                listaDeAtivos = new List<Ativos>();
            }
            public void AdicionarAtivo(Ativos novoAtivo)
            {
                listaDeAtivos.Add(novoAtivo);
                CalcularPrecoMedio();
            }

            private void CalcularPrecoMedio()
            {
                double totalPreco = 0;
                int totalQuantidade = 0;

                foreach (var ativo in listaDeAtivos)
                {
                    totalPreco += ativo.PrecoMedio * ativo.Quantidade;
                    totalQuantidade += ativo.Quantidade;
                }

                if (totalQuantidade != 0)
                {
                    double novoPrecoMedio = totalPreco / totalQuantidade;

                    foreach (var ativo in listaDeAtivos)
                    {
                        ativo.PrecoMedio = novoPrecoMedio;
                    }
                }
            }

        }
    }
}
