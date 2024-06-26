﻿using CarteiraDoInvestidor.Domain.Financeiro.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Test.Domain
{
    public class CartaoTest
    {
        [Fact]
        public void DeveCriarTransacaoComSucesso()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = "6465465466",
                Validade = DateTime.Now.AddYears(2),
                CVV = 123
            };

            var merchant = new CarteiraDoInvestidor.Domain.ValueObject.Merchant()
            {
                Nome = "Dummy"
            };

            cartao.CriarTransacao(merchant, 19M, "Dummy Transacao");
            Assert.True(cartao.Transacoes.Count > 0);
            Assert.True(cartao.Limite == 981M);

        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoInativo()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = false,
                Limite = 1000M,
                Numero = "6465465466",
                Validade = DateTime.Now.AddYears(2),
                CVV = 123
            };

            var merchant = new CarteiraDoInvestidor.Domain.ValueObject.Merchant()
            {
                Nome = "Dummy"
            };

            Assert.Throws<System.Exception>(
                () => cartao.CriarTransacao(merchant, 19M, "Dummy Transacao"));
        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoSemLimite()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 10M,
                Numero = "6465465466",
                Validade = DateTime.Now.AddYears(2),
                CVV = 123
            };

            var merchant = new CarteiraDoInvestidor.Domain.ValueObject.Merchant()
            {
                Nome = "Dummy"
            };

            Assert.Throws<System.Exception>(
                () => cartao.CriarTransacao(merchant, 19M, "Dummy Transacao"));
        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoValorDuplicado()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = "6465465466",
                Validade = DateTime.Now.AddYears(2),
                CVV = 123
            };

            cartao.Transacoes.Add(new CarteiraDoInvestidor.Domain.Financeiro.Agreggates.Transacao()
            {
                DtTransacao = DateTime.Now,
                Id = Guid.NewGuid(),
                Merchant = new CarteiraDoInvestidor.Domain.ValueObject.Merchant()
                {
                    Nome = "Dummy"
                },
                Valor = 19M,
                Descricao = "saljasdlak"
            });

            var merchant = new CarteiraDoInvestidor.Domain.ValueObject.Merchant()
            {
                Nome = "Dummy"
            };

            Assert.Throws<System.Exception>(
                () => cartao.CriarTransacao(merchant, 19M, "Dummy Transacao"));

        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoAltoFrequencia()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1000M,
                Numero = "6465465466",
                Validade = DateTime.Now.AddYears(2),
                CVV = 123
            };

            cartao.Transacoes.Add(new CarteiraDoInvestidor.Domain.Financeiro.Agreggates.Transacao()
            {
                DtTransacao = DateTime.Now.AddMinutes(-1),
                Id = Guid.NewGuid(),
                Merchant = new CarteiraDoInvestidor.Domain.ValueObject.Merchant()
                {
                    Nome = "Dummy"
                },
                Valor = 19M,
                Descricao = "saljasdlak"
            });

            cartao.Transacoes.Add(new CarteiraDoInvestidor.Domain.Financeiro.Agreggates.Transacao()
            {
                DtTransacao = DateTime.Now.AddMinutes(-0.5),
                Id = Guid.NewGuid(),
                Merchant = new CarteiraDoInvestidor.Domain.ValueObject.Merchant()
                {
                    Nome = "Dummy"
                },
                Valor = 19M,
                Descricao = "saljasdlak"
            });

            cartao.Transacoes.Add(new CarteiraDoInvestidor.Domain.Financeiro.Agreggates.Transacao()
            {
                DtTransacao = DateTime.Now,
                Id = Guid.NewGuid(),
                Merchant = new CarteiraDoInvestidor.Domain.ValueObject.Merchant()
                {
                    Nome = "Dummy"
                },
                Valor = 19M,
                Descricao = "saljasdlak"
            });


            var merchant = new CarteiraDoInvestidor.Domain.ValueObject.Merchant()
            {
                Nome = "Dummy"
            };

            Assert.Throws<System.Exception>(
                () => cartao.CriarTransacao(merchant, 19M, "Dummy Transacao"));
        }
    }
}
