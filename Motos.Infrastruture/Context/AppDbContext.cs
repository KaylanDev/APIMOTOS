using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Motos.Domain.Entities;

using Motos.Infrastruture.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Infrastruture.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRoles, string>
    {

        // Hash gerado previamente para a senha "@Kayzin205!"
   

       private ApplicationUser adminUser = new ApplicationUser
        {
            Id = "1",
            UserName = "Kaylan",
            NormalizedUserName = "KAYLAN",
            FullName = "Kaylan alexandre de paula sathler",
            PasswordHash = "AQAAAAIAAYagAAAAEMZ57cR8Zuw29LroyRIPeGlFW/X8I25aQ1aAdsG17XTPxwJtjOHLXV91pLzSYM4SpA==",
           SecurityStamp = "185ced58-529c-4389-b30a-ab40073d5a9f",
           ConcurrencyStamp = "c7331179-06a2-4b04-84dd-f64f9689fa44"
       };

        public  AppDbContext(DbContextOptions options) : base(options)
        {
        }

      private   ApplicationRoles funcionarioRole = new ApplicationRoles { Id = "1", Name = "Funcionario", NormalizedName = "FUNCIONARIO", 
            Description = "apenas para funcionarios. tem acessa apenas a vizualizar." };
      private  ApplicationRoles supervisorRole = new ApplicationRoles { Id = "2", Name = "Supervisor", NormalizedName = "SUPERVISOR",
            Description = "apenas para servisores. tem acesso a vizualizar e adcionar" };
       private ApplicationRoles gerenteRole = new ApplicationRoles { Id = "3", Name = "Gerente", NormalizedName = "GERENTE",
            Description = "apenas para gerentes. tem acessa  a vizualizar,adcionar,modificar e apagar" };
      private  ApplicationRoles DesenvolvedorRole = new ApplicationRoles { Id = "4", Name = "Dev", NormalizedName = "DEV", 
            Description = "apenas para desenvolvedores" };


        public DbSet<MotosM> MotosM { get; set; }
        public DbSet<Marca> Marca { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            // --- SEED DE ROLES ---


            builder.Entity<ApplicationRoles>().HasData(
                funcionarioRole,
                supervisorRole,
                gerenteRole,
                DesenvolvedorRole
            );


          builder.Entity<ApplicationUser>().HasData(adminUser);
            
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = DesenvolvedorRole.Id, UserId = adminUser.Id }
      
      
            );
      
            // --- FIM DO SEED DE ROLES ---
        }
    }
}
