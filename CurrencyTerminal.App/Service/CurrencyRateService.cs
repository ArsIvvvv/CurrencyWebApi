using AutoMapper;
using CurrencyTerminal.App.Common;
using CurrencyTerminal.App.DTO;
using CurrencyTerminal.App.Interfaces;
using CurrencyTerminal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTerminal.App.Service
{
    public class CurrencyRateService : ICurrencyRateService
    {
        private readonly ICurrencyRepository _currencyRateRepository;
        private readonly IMapper _mapper;
        public CurrencyRateService(ICurrencyRepository currencyRateRepository, IMapper mapper) 
        {
            _currencyRateRepository = currencyRateRepository;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<CurrencyRateDto>>> GetAllCurrencyRate(DateTime? onDate = null)
        {
           var currencyRateList = await _currencyRateRepository.GetAllCurrencyRateAsync(onDate);

            if (!currencyRateList.Any() && onDate.HasValue)
                return Result<IEnumerable<CurrencyRateDto>>
                    .Failure($"Список валют с датой {onDate} отсутствует в базе!");

            return Result<IEnumerable<CurrencyRateDto>>
                .Success(_mapper.Map<IEnumerable<CurrencyRateDto>>(currencyRateList));
        }
    }
}
