using CarteiraDoInvestidor.CrossCuting.Entity;
using CarteiraDoInvestidor.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Domain.Financeiro.Agreggates
{
    public class Cartao : Entity<Guid>
    {

        private const int INTERVALO_TRANSACAO = -2;
        private const int REPETICAO_TRANSACAO_MERCHANT = 1;

        public Boolean Ativo { get; set; }
        public Monetario Limite { get; set; }
        public String Numero { get; set; }
        public DateTime Validade { get; set; }
        public int CVV { get; set; }
        public virtual IList<Transacao> Transacoes { get; set; } = new List<Transacao>();

        public void CriarTransacao(Merchant merchant, Monetario valor, string Descricao = "")
        {
            //Verificar se um cartão está ativo 
            this.IsCartaoAtivo();

            //Objeto Transacao
            Transacao transacao = new Transacao();
            transacao.Merchant = merchant;
            transacao.Valor = valor;
            transacao.Descricao = Descricao;
            transacao.DtTransacao = DateTime.Now;

            //Verificar limite disponível
            this.VerificaLimite(transacao);

            //Verificar Regras Antifraude
            this.ValidarTransacao(transacao);

            //Criar numero de autorização
            transacao.Id = Guid.NewGuid();

            //Diminui o limite com o valor da transacao
            this.Limite = this.Limite - transacao.Valor;

            //Criar transação
            this.Transacoes.Add(transacao);
        }

        private void ValidarTransacao(Transacao transacao)
        {
            //Regra de negócio: Não permite realizar transações de mesmo valor em menos de 2 minutos 
            var ultimasTransacoes = this.Transacoes.Where(x => x.DtTransacao >= DateTime.Now.AddMinutes(INTERVALO_TRANSACAO));

            if (ultimasTransacoes?.Count() >= 3)
            {
                throw new Exception("Cartão ultilizado muitas vezes em período curto");
            }

            //Regra de negócio: Não permite realizar transações de mesmo merchant ao mesmo tempo
            var transacaoRepetidaporMerchant = ultimasTransacoes?
                                                .Where(x => x.Merchant.Nome.ToUpper() == transacao.Merchant.Nome.ToUpper() && x.Valor == transacao.Valor)
                                                .Count() == REPETICAO_TRANSACAO_MERCHANT;

            if (transacaoRepetidaporMerchant)
            {
                throw new Exception("Transação duplicada para o mesmo cartão e o mesmo Comerciante");
            }

        }

        private void VerificaLimite(Transacao transacao)
        {
            if (this.Limite < transacao.Valor)
            {
                throw new Exception("Cartão não possui limite para está transação");
            }
        }

        private void IsCartaoAtivo()
        {
            if (this.Ativo == false)
            {
                throw new Exception("Cartão não está ativo");
            }
        }
    }
}
