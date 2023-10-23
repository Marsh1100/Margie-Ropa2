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

public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
{
    public void Configure(EntityTypeBuilder<Proveedor> builder)
    {
        builder.ToTable("proveedor");

        builder.Property(p => p.Id)
            .IsRequired();
        
        builder.Property(p => p.NitProveedor)
            .HasMaxLength(100)
            .IsRequired();
        builder.HasIndex(p=>p.NitProveedor)
            .IsUnique();
        builder.Property(p => p.Nombre)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(p=> p.TipoPersona)
            .WithMany(p => p.Proveedores)
            .HasForeignKey(p=>p.TipoPersonaId);
        builder.HasOne(p=> p.Municipio)
            .WithMany(p => p.Proveedores)
            .HasForeignKey(p=>p.MunicipioId);
        
    }

}
