using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class PrendaConfiguration : IEntityTypeConfiguration<Prenda>
{
    public void Configure(EntityTypeBuilder<Prenda> builder)
    {
        builder.ToTable("prenda");

        builder.Property(p => p.Id)
            .IsRequired();
        
        builder.Property(p => p.IdPrenda)
            .HasMaxLength(100)
            .IsRequired();
        builder.HasIndex(p=>p.IdPrenda)
            .IsUnique();
        builder.Property(p => p.Nombre)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(p => p.ValorUnitCOP)
            .IsRequired();
        builder.Property(p => p.ValorUnitUSD)
            .IsRequired();

        builder.HasOne(p=> p.Estado)
            .WithMany(p => p.Prendas)
            .HasForeignKey(p=>p.EstadoId);
        builder.HasOne(p=> p.TipoProteccion)
            .WithMany(p => p.Prendas)
            .HasForeignKey(p=>p.TipoProteccionId);
        builder.HasOne(p=> p.Genero)
            .WithMany(p => p.Prendas)
            .HasForeignKey(p=>p.GeneroId);
    }

}
