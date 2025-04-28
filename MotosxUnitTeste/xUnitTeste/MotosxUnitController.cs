using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Motos.Data;
using Motos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotosxUnitTeste.xUnitTeste
{
    public class MotosxUnitController
    {
        public IUnitOfWork uof;
        public static DbContextOptions<AppDbContext> dbContextOptions { get; }

        public static string conectionString = "Data Source=SHEISLINDA;Initial Catalog=MotosProject;Integrated Security=True;Trust Server Certificate=True";
        static MotosxUnitController()
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(conectionString).Options;
        }

        public MotosxUnitController()
        {

            var context = new AppDbContext(dbContextOptions);
            uof = new UnitOfWork(context);

        }



    }
}
