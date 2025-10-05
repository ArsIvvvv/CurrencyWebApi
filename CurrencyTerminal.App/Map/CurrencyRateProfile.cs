using AutoMapper;
using CurrencyTerminal.App.DTO;
using CurrencyTerminal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTerminal.App.Map
{
    public class CurrencyRateProfile : Profile
    {
        public CurrencyRateProfile()
        {
            CreateMap<CurrencyRate, CurrencyRateDto>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate))
                .ForMember(dest => dest.Nominal, opt => opt.MapFrom(src => src.Nominal));
        }

    }
}
