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

public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
{
    public void Configure(EntityTypeBuilder<Empresa> builder)
    {
        builder.ToTable("empresa");

        builder.Property(p => p.Id)
            .IsRequired();
        builder.Property(p => p.NIT)
            .HasMaxLength(50)
            .IsRequired();
        builder.HasIndex(p=> p.NIT)
            .IsUnique();
        builder.Property(p => p.RazonSocial)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(p => p.FechaCreacion)
            .IsRequired();
        
        builder.HasOne(p=> p.Municipio)
            .WithMany(p => p.Empresas)
            .HasForeignKey(p=>p.MunicipioId);

    }
        

}
