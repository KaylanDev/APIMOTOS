using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Motos.Application.Interfaces;
using Motos.Application.Service;
using Motos.Application.Services;
using Motos.Domain.Services;
using Motos.Application.TokenService;
using Motos.Application.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Application.IocApp;

public static class DependencyInjetionApp
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssemblyContaining<MotoValidator>();
        services.AddValidatorsFromAssemblyContaining<MarcaValidator>();
        services.AddScoped<IMotosMService, MotosMService>();
        services.AddScoped<IMarcaService, MarcaService>();
        services.AddScoped<ICacheService, CacheService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();

        return services;
    }

 

}
