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

public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {
        builder.ToTable("detalleVenta");

        builder.Property(p => p.Id)
            .IsRequired();
        
        builder.Property(p => p.Cantidad)
            .IsRequired();
        builder.Property(p => p.ValorUnitCOP)
            .IsRequired();

        builder.HasOne(p=> p.Venta)
            .WithMany(p => p.DetalleVentas)
            .HasForeignKey(p=>p.VentaId);
        builder.HasOne(p=> p.Prenda)
            .WithMany(p => p.DetalleVentas)
            .HasForeignKey(p=>p.PrendaId);
        builder.HasOne(p=> p.Talla)
            .WithMany(p => p.DetalleVentas)
            .HasForeignKey(p=>p.TallaId);
    }
        

}
