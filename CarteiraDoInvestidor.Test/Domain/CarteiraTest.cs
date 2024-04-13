using CarteiraDoInvestidor.Api.Controllers;
using CarteiraDoInvestidor.Application.Investimentos;
using CarteiraDoInvestidor.Application.Investimentos.Dto;
using CarteiraDoInvestidor.Domain.Carteira.Agreggates;
using CarteiraDoInvestidor.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Test.Domain
{
    public class CarteiraTest
    {

        [Fact]
        public void CriarCarteira_DeveRetornarOkComNovaCarteira()
        {
            // Arrange
            var carteiraServiceMock = new Mock<CarteiraService>();
            var carteiraRepositoryMock = new Mock<InterfaceBase<Carteiras>>();
            var controller = new CarteiraController(carteiraServiceMock.Object);
            var carteiraDto = new CarteirasDto
            {
                NomeCarteira = "Minha Carteira",
                Descricao = "Descrição da minha carteira",
                DataCriacao = DateTime.Now,
                UsuarioId = Guid.NewGuid(),
                Ativos = new List<AtivosDto>
                {
                    new AtivosDto
                    {
                        Papel = "AAPL",
                        Quantidade = 10,
                        PrecoMedio = 150.0,
                        Corretora = "Corretora XYZ",
                        TaxaDeCorretagem = 5.0,
                        DataDaCompra = DateTime.Now,
                        LadoDaOperacao = "Compra"
                    }
                }
            };

            var novaCarteira = new Carteiras
            {
                Id = Guid.NewGuid(),
                NomeCarteira = carteiraDto.NomeCarteira,
                Descricao = carteiraDto.Descricao,
                DataCriacao = carteiraDto.DataCriacao,
                UsuarioId = carteiraDto.UsuarioId,
                ListaDeAtivos = carteiraDto.Ativos.Select(a => new Ativos
                {
                    Id = Guid.NewGuid(),
                    Papel = a.Papel,
                    Quantidade = a.Quantidade,
                    PrecoMedio = a.PrecoMedio,
                    Corretora = a.Corretora,
                    TaxaDeCorretagem = a.TaxaDeCorretagem,
                    DataDaCompra = a.DataDaCompra,
                    LadoDaOperacao = a.LadoDaOperacao
                }).ToList()
            };

          

            // Act
            var result = controller.CriarCarteira(carteiraDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultCarteira = Assert.IsType<Carteiras>(okResult.Value);
            Assert.Equal(novaCarteira, resultCarteira);
        }
    }
    }