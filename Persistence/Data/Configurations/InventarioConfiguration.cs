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

public class InventarioConfiguration : IEntityTypeConfiguration<Inventario>
{
    public void Configure(EntityTypeBuilder<Inventario> builder)
    {
        builder.ToTable("inventario");

        builder.Property(p => p.Id)
            .IsRequired();
        
        builder.Property(p => p.CodInv)
            .HasMaxLength(150)
            .IsRequired();
        builder.HasIndex(p=>p.CodInv)
            .IsUnique();
        
        builder.HasOne(p=> p.Prenda)
            .WithMany(p => p.Inventarios)
            .HasForeignKey(p=>p.PrendaId);
      
        builder.Property(p => p.ValorVentaCOP)
            .IsRequired();
        builder.Property(p => p.ValorVentaUSD)
            .IsRequired();
        
        builder
            .HasMany(p=>p.Tallas)
            .WithMany(p=>p.Inventarios)
            .UsingEntity<InventarioTalla>(
                j=> j
                    .HasOne(t=> t.Talla)
                    .WithMany(m=> m.InventarioTallas)
                    .HasForeignKey(f=> f.TallaId),
                j=> j
                    .HasOne(t=> t.Inventario)
                    .WithMany(m=>m.InventarioTallas)
                    .HasForeignKey(f=> f.InventarioId),
                j=>
                {
                    j.ToTable("inventarioTalla");
                    j.HasKey(t=> new {t.InventarioId, t.TallaId});
                    j.Property(p=> p.Cantidad);
                }
            );
    }

}
