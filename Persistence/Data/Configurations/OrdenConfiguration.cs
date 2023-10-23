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

public class OrdenConfiguration : IEntityTypeConfiguration<Orden>
{
    public void Configure(EntityTypeBuilder<Orden> builder)
    {
        builder.ToTable("orden");

        builder.Property(p => p.Id)
            .IsRequired();
        
        builder.Property(p => p.Fecha)
            .IsRequired();
    
        builder.HasOne(p=> p.Empleado)
            .WithMany(p => p.Ordenes)
            .HasForeignKey(p=>p.EmpleadoId);
        builder.HasOne(p=> p.Cliente)
            .WithMany(p => p.Ordenes)
            .HasForeignKey(p=>p.ClienteId);
        builder.HasOne(p=> p.Estado)
            .WithMany(p => p.Ordenes)
            .HasForeignKey(p=>p.EstadoId);
    }

}
