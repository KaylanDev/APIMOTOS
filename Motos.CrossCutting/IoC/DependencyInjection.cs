

using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Motos.API.Model.Validator;
using Motos.Application.Interfaces;
using Motos.Application.Service;
using Motos.Application.Services;
using Motos.Domain.Entities;
using Motos.Domain.Interfaces;
using Motos.Infrastruture.Context;
using Motos.Infrastruture.Repository;
using System.ComponentModel.Design;



namespace Motos.CrossCutting.IoC
{
   public  static class DependencyInjection
    {
        public static IServiceCollection Addinfrastruture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlserver"),b => b.MigrationsAssembly("Motos.Infrastruture")));

            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddValidatorsFromAssemblyContaining<MotoValidator>();
            services.AddValidatorsFromAssemblyContaining<MarcaValidator>();
            services.AddScoped<IMotosRepository, MotosMRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IMotosMService, MotosMService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICacheService,CacheService>();
        
            return services;
        }
    }
}
