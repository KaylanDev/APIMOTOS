using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motos.Infrastruture.Configuration
{
    class MotosMConfiguration : IEntityTypeConfiguration<MotosM>
    {
        public void Configure(EntityTypeBuilder<MotosM> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Modelo)
                .IsRequired()
                .HasMaxLength(25);
            builder.Property(m => m.Potencia)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(m => m.Preco)
                .HasColumnType("decimal(18,2)").IsRequired();
            
            builder.Property(m => m.Imagem)
                    .IsRequired()
                    .HasMaxLength(500);

            builder.HasOne<Marca>().WithMany(m => m.Motos)
                .HasForeignKey(m => m.Id)

                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
