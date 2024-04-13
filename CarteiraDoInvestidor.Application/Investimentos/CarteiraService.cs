using AutoMapper;
using CarteiraDoInvestidor.Application.Investimentos.Dto;
using CarteiraDoInvestidor.Domain.Carteira.Agreggates;
using CarteiraDoInvestidor.Repository;
using CarteiraDoInvestidor.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Application.Investimentos
{
    public class CarteiraService
    {
        private CarteiraRepository CarteiraRepository { get; set; }
        private IMapper Mapper { get; set; }

        public CarteiraService(CarteiraRepository carteiraRepository, IMapper mapper)
        {
            CarteiraRepository = carteiraRepository;
            Mapper = mapper;
        }


        public CarteirasDto ObterCarteiraPorId(Guid carteiraId)
        {
            var carteira = CarteiraRepository.GetById(carteiraId);
            return Mapper.Map<CarteirasDto>(carteira);
        }

        public CarteirasDto ObterCarteiraseAtivos(Guid carteiraId)
        {
            var carteira = CarteiraRepository.GetByIdWithIncludes(carteiraId, c => c.ListaDeAtivos);
            return Mapper.Map<CarteirasDto>(carteira);
        }

        public void AtualizarCarteira(CarteirasDto carteiraDto)
        {
            var carteira = Mapper.Map<Carteiras>(carteiraDto);
            CarteiraRepository.Update(carteira);
        }

        public void AtualizarAtivos(Guid carteiraId, List<AtivosDto> novosAtivos)
        {
            var carteira = CarteiraRepository.GetByIdWithIncludes(carteiraId, c => c.ListaDeAtivos);
            carteira.ListaDeAtivos.Clear();
            carteira.ListaDeAtivos.AddRange(novosAtivos.Select(Mapper.Map<Ativos>));
            CarteiraRepository.Update(carteira);
        }

        public void DeletarTodosAtivos(Guid carteiraId)
        {
            var carteira = CarteiraRepository.GetByIdWithIncludes(carteiraId, c => c.ListaDeAtivos);
            carteira.ListaDeAtivos.Clear();
            CarteiraRepository.Update(carteira);
        }


        public void DeletarCarteira(Guid carteiraId)
        {
            var carteira = CarteiraRepository.GetByIdWithIncludes(carteiraId, c => c.ListaDeAtivos);

            CarteiraRepository.Delete(carteira);
        }

        public void CriarAtivoAssociadoACarteira(Guid carteiraId, AtivosDto novoAtivoDto)
        {
            var novoAtivo = Mapper.Map<Ativos>(novoAtivoDto);
            var carteira = CarteiraRepository.GetById(carteiraId);
            carteira.ListaDeAtivos.Add(novoAtivo);
            CarteiraRepository.Update(carteira);
        }
        public CarteirasDto Criar(CarteirasDto dto)
        {
            Carteiras carteiras = this.Mapper.Map<Carteiras>(dto);
            this.CarteiraRepository.Save(carteiras);
            CarteirasDto savedDto = this.Mapper.Map<CarteirasDto>(carteiras);

            return savedDto;
        }


    }

}

