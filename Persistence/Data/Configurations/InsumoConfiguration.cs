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

public class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
{
    public void Configure(EntityTypeBuilder<Insumo> builder)
    {
        builder.ToTable("insumo");

        builder.Property(p => p.Id)
            .IsRequired();
        
        builder.Property(p => p.Nombre)
            .HasMaxLength(50)
            .IsRequired();
        builder.HasIndex(p=>p.Nombre)
            .IsUnique();
        builder.Property(p => p.ValorUnit)
            .IsRequired();
        builder.Property(p => p.StockMin)
            .IsRequired();
        builder.Property(p => p.StockMax)
            .IsRequired();    

        builder
            .HasMany(p=>p.Proveedores)
            .WithMany(p=>p.Insumos)
            .UsingEntity<InsumoProveedor>(
                j=> j
                    .HasOne(t=> t.Proveedor)
                    .WithMany(m=> m.InsumoProveedores)
                    .HasForeignKey(f=> f.ProveedorId),
                j=> j
                    .HasOne(t=> t.Insumo)
                    .WithMany(m=>m.InsumoProveedores)
                    .HasForeignKey(f=> f.InsumoId),
                j=>
                {
                    j.ToTable("insumoProveedor");
                    j.HasKey(t=> new {t.ProveedorId, t.InsumoId});
                }
            );

            builder
            .HasMany(p=>p.Prendas)
            .WithMany(p=>p.Insumos)
            .UsingEntity<InsumoPrenda>(
                j=> j
                    .HasOne(t=> t.Prenda)
                    .WithMany(m=> m.InsumoPrendas)
                    .HasForeignKey(f=> f.PrendaId),
                j=> j
                    .HasOne(t=> t.Insumo)
                    .WithMany(m=>m.InsumoPrendas)
                    .HasForeignKey(f=> f.InsumoId),
                j=>
                {
                    j.ToTable("insumoPrenda");
                    j.HasKey(t=> new {t.PrendaId, t.InsumoId});
                    j.Property(p=> p.Cantidad);
                }
            );

    }

}
