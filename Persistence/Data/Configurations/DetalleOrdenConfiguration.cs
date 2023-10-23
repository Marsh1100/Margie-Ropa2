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

public class DetalleOrdenConfiguration : IEntityTypeConfiguration<DetalleOrden>
{
    public void Configure(EntityTypeBuilder<DetalleOrden> builder)
    {
        builder.ToTable("detalleOrden");

        builder.Property(p => p.Id)
            .IsRequired();
        
        builder.Property(p => p.CantidadProducida)
            .IsRequired();

        builder.HasOne(p=> p.Orden)
            .WithMany(p => p.DetalleOrdenes)
            .HasForeignKey(p=>p.OrdenId);
        builder.HasOne(p=> p.Prenda)
            .WithMany(p => p.DetalleOrdenes)
            .HasForeignKey(p=>p.PrendaId);
        builder.HasOne(p=> p.Color)
            .WithMany(p => p.DetalleOrdenes)
            .HasForeignKey(p=>p.ColorId);
    }

}
