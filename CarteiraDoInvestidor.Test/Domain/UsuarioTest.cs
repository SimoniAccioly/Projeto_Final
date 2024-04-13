using CarteiraDoInvestidor.Domain.Conta.Agreggates;
using CarteiraDoInvestidor.Domain.Financeiro.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Test.Domain
{
    public class UsuarioTest
    {
        [Fact]
        public void DeveCriarUsuarioComSucesso()
        {
            Plano plano = new Plano()
            {
                Descricao = "Lorem ipsum",
                Id = Guid.NewGuid(),
                Nome = "Plano Dummy",
                Valor = 19.90M
            };

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = "6465465466",
            };

            string nome = "Dummy Usuario";
            string email = "teste@teste.com";
            string cpf = "000.000.000-000";
            string senha = "123456";

            //Act
            Usuario usuario = new Usuario();
            usuario.CriarConta(nome, email, senha, cpf, DateTime.Now, plano, cartao);

            //Assert
            Assert.NotNull(usuario.Email);
            Assert.NotNull(usuario.Nome);
            Assert.True(usuario.Email == email);
            Assert.True(usuario.Nome == nome);
            Assert.True(usuario.CPF == cpf);
            Assert.True(usuario.Senha != senha);

            Assert.True(usuario.Assinaturas.Count > 0);
            Assert.Same(usuario.Assinaturas[0].Plano, plano);

            Assert.True(usuario.Cartoes.Count > 0);
            Assert.Same(usuario.Cartoes[0], cartao);

        }

        [Fact]
        public void NaoDeveCriarUsuarioComCartaoSemLimite()
        {
            Plano plano = new Plano()
            {
                Descricao = "Lorem ipsum",
                Id = Guid.NewGuid(),
                Nome = "Plano Dummy",
                Valor = 19.90M
            };

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 10M,
                Numero = "6465465466",
            };

            string nome = "Dummy Usuario";
            string email = "teste@teste.com";
            string cpf = "000.000.000-000";
            string senha = "123456";

            //Act
            Assert.Throws<Exception>(() =>
            {
                Usuario usuario = new Usuario();
                usuario.CriarConta(nome, email, senha, cpf, DateTime.Now, plano, cartao);
            });
        }

       
    }
}
