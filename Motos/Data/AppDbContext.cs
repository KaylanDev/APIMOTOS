using Microsoft.EntityFrameworkCore;
using Motos.API.Model;

namespace Motos.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MotosM> MotosM { get; set; }
        public DbSet<Marca> Marca { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MotosM>()
                .HasOne(m => m.Marca)
                .WithMany(m => m.Motos)
                .HasForeignKey(m => m.MarcaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
