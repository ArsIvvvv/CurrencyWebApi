using CurrencyTerminal.App.Interfaces;
using CurrencyTerminal.App.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTerminal.App
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyRateService, CurrencyRateService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
