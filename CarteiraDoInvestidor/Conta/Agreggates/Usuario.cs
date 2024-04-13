using CarteiraDoInvestidor.CrossCuting.Entity;
using CarteiraDoInvestidor.CrossCuting.Utils;
using CarteiraDoInvestidor.Domain.Financeiro.Agreggates;
using CarteiraDoInvestidor.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using CarteiraDoInvestidor.Domain.Carteira.Agreggates;


namespace CarteiraDoInvestidor.Domain.Conta.Agreggates
{
    public class Usuario : Entity<Guid>
    {
        private const string NOME_CARTEIRA = "Carteira Padrão";
        private const string DESCRICAO_PADRAO = "Carteira Padrão para inclusão de ativos";
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DtNascimento { get; set; }
        public string CPF { get; set; }
        public virtual IList<Cartao> Cartoes { get; set; } = new List<Cartao>();
        public virtual IList<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
        public virtual IList<Carteiras> Carteiras { get; set; } = new List<Carteiras>();

        public virtual IList<Notificacao> Notificacoes { get; set; } = new List<Notificacao>();


        public void CriarConta(string nome, string email, string senha, string cpf, DateTime dtNascimento, Plano plano, Cartao cartao)
        {
            Nome = nome;
            Email = email;
            CPF = cpf;
            DtNascimento = dtNascimento;

            //Criptografar a senha
            Senha = CriptografarSenha(senha);

            //Assinar um plano
            AssinarPlano(plano, cartao);

            //Adicionar cartão na conta do usuário
            AdicionarCartao(cartao);

            //Criar a playlist padrão do usuario
            CriarCarteira(nomeCarteira: NOME_CARTEIRA, descricao: DESCRICAO_PADRAO);
        }

        private void AdicionarCartao(Cartao cartao)
            => Cartoes.Add(cartao);

        private void AssinarPlano(Plano plano, Cartao cartao)
        {
            //Debitar o valor do plano no cartao
            cartao.CriarTransacao(new Merchant() { Nome = plano.Nome }, new Monetario(plano.Valor), plano.Descricao);

            //Desativo caso tenha alguma assinatura ativa
            DesativarAssinaturaAtiva();

            //Adiciona uma nova assinatura
            Assinaturas.Add(new Assinatura()
            {
                Ativo = true,
                Plano = plano,
                DtAtivacao = DateTime.Now,
            });

        }

        private void DesativarAssinaturaAtiva()
        {
            //Caso tenha alguma assintura ativa, deseativa ela
            if (Assinaturas.Count > 0 && Assinaturas.Any(x => x.Ativo))
            {
                var planoAtivo = Assinaturas.FirstOrDefault(x => x.Ativo);
                planoAtivo.Ativo = false;
            }
        }

        public void CriarCarteira(string nomeCarteira, string descricao)
        {
            Carteiras.Add(new Carteiras()
            {
                NomeCarteira = nomeCarteira,
                Descricao = descricao,
                DataCriacao = DateTime.Now,
                Usuario = this
            });
        }

        private string CriptografarSenha(string senhaAberta)
        {
            return senhaAberta.HashSHA256();
        }


    }
}
