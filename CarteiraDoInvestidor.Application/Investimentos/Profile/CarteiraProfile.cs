using CarteiraDoInvestidor.Application.Investimentos.Dto;
using CarteiraDoInvestidor.Domain.Carteira.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteiraDoInvestidor.Application.Investimentos.Profile
{
    public class CarteiraProfile : AutoMapper.Profile
    {
        public CarteiraProfile() 
        {
            CreateMap<CarteirasDto, Carteiras>()
                .ReverseMap();

            CreateMap<AtivosDto, Ativos>()
                .ReverseMap();
        }
    }
}
