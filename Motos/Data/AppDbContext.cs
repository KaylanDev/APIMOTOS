using Microsoft.EntityFrameworkCore;

using Motos.Model;

namespace Motos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MotosM> MotosM { get; set; }
        public DbSet<Marca> Marca { get; set; }


    }
}
