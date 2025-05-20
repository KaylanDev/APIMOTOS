using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Motos.Application.Interfaces;
using Motos.Application.Service;
using Motos.Application.Services;
using Motos.Infrastruture.Context;
using Motos.Infrastruture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotosxUnitTeste.xUnitTeste
{
    public class MotosxUnitController
    {
        public IMotosMService motos;
       public ICacheService cacheService;
        public static DbContextOptions<AppDbContext> dbContextOptions { get; }

        public static string conectionString = "Data Source=SHEISLINDA;Initial Catalog=MotosAPI;Integrated Security=True;Trust Server Certificate=True";
        static MotosxUnitController()
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(conectionString).Options;
        }

        public MotosxUnitController()
        {
            var context = new AppDbContext(dbContextOptions);
            motos = new MotosMService(new MotosMRepository(context), new MarcaRepository(context));

            // Instanciando MemoryCache com opções padrão para uso em testes xUnit
            var memoryCacheOptions = new MemoryCacheOptions();
            var memoryCache = new MemoryCache(memoryCacheOptions);
            cacheService = new CacheService(memoryCache);
        }



    }
}
