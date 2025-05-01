

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Motos.Application.Interfaces;
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
            services.AddScoped<IMotosRepository, MotosMRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IMotosMService, MotosMService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
            return services;
        }
    }
}
