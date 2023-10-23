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

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cliente");

        builder.Property(p => p.Id)
            .IsRequired();
        
        builder.Property(p => p.IdCliente)
            .HasMaxLength(15)
            .IsRequired();
        builder.HasIndex(p=> p.IdCliente)
            .IsUnique();
        builder.Property(p => p.Nombre)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.HasOne(p=> p.TipoPersona)
            .WithMany(p => p.Clientes)
            .HasForeignKey(p=>p.TipoPersonaId);
        
        builder.Property(p => p.FechaRegistro)
            .IsRequired();
        builder.HasOne(p=> p.Municipio)
            .WithMany(p => p.Clientes)
            .HasForeignKey(p=>p.MunicipioId);
    }

}
