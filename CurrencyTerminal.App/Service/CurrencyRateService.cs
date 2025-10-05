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

        public async Task<Result<Dictionary<string,string>>> GetAllCurrencyCodesAsync()
        {
            var codes = new Dictionary<string, string>();

            var currencyRateList = await _currencyRateRepository.GetAllCurrencyRateAsync();

            if(!currencyRateList.Any())
                return Result<Dictionary<string, string>>
                    .Failure($"Ошибка запроса к службам банка");
           
            foreach(var code in currencyRateList)
            {
                codes[code.Code] = code.Name; 
            }

            return Result<Dictionary<string, string>>
               .Success(codes);

        }

        public async Task<Result<IEnumerable<CurrencyRateDto>>> GetAllCurrencyRates(DateTime? onDate = null)
        {
           var currencyRateList = await _currencyRateRepository.GetAllCurrencyRateAsync(onDate);

            if (!currencyRateList.Any() && onDate.HasValue)
                return Result<IEnumerable<CurrencyRateDto>>
                    .Failure($"Список валют с датой {onDate} отсутствует в базе!");

            return Result<IEnumerable<CurrencyRateDto>>
                .Success(_mapper.Map<IEnumerable<CurrencyRateDto>>(currencyRateList));
        }

        public async Task<Result<CurrencyRateDto>> GetCurrencyRateAsync(string currenctCode, DateTime? onDate = null)
        {
            var currencyRate = await _currencyRateRepository.GetCurrencyRateAsync(currenctCode,onDate);

            if (currencyRate == null && onDate.HasValue)
                return Result<CurrencyRateDto>
                    .Failure($"Нет курса с таким кодом {currenctCode}");

            return Result<CurrencyRateDto>
                .Success(_mapper.Map<CurrencyRateDto>(currencyRate));
        }
    }
}
