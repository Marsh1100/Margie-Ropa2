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

public class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("venta");

        builder.Property(p => p.Id)
            .IsRequired();
        
        builder.Property(p => p.Fecha)
            .IsRequired();
        builder.HasOne(p=> p.Empleado)
            .WithMany(p => p.Ventas)
            .HasForeignKey(p=>p.EmpleadoId);
        builder.HasOne(p=> p.Cliente)
            .WithMany(p => p.Ventas)
            .HasForeignKey(p=>p.ClienteId);
        builder.HasOne(p=> p.FormaPago)
            .WithMany(p => p.Ventas)
            .HasForeignKey(p=>p.FormaPagoId);
        
    }

}
