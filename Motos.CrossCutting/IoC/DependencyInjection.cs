

using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Motos.Application.Interfaces;
using Motos.Application.Service;
using Motos.Application.Services;
using Motos.Domain.Entities;
using Motos.Domain.Interfaces;
using Motos.Infrastruture.Context;
using Motos.Infrastruture.Repository;
using System.ComponentModel.Design;
using System.Reflection;
using Motos.Application.IocApp;



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
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddIdentity<ApplicationUser, ApplicationRoles>(options =>
            {
                // Configure as opções de segurança do Identity aqui
                // Estas são as configurações de senha. Ajuste-as conforme suas necessidades de segurança
                options.Password.RequireDigit = false; // Exige um número
                options.Password.RequiredLength = 6; // Comprimento mínimo

                // Opções de lockout (bloqueio da conta após falhas de login)
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // Opções de usuário
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._"; // Caracteres permitidos no nome de usuário

                // Opções de SignIn (login)
                options.SignIn.RequireConfirmedAccount = false; // Exige que a conta seja confirmada para login

            }).AddEntityFrameworkStores<AppDbContext>()// Conecta o Identity ao Entity Framework Core e ao seu DbContext
            .AddDefaultTokenProviders(); // Adiciona os provedores de token padrão(para redefinição de senha, confirmação de e-mail, etc.)
            services.AddApplication();

            return services;
        }
    }
}
