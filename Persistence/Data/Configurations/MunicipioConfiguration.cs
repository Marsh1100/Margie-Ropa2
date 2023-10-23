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

public class MunicipioConfiguration : IEntityTypeConfiguration<Municipio>
{
    public void Configure(EntityTypeBuilder<Municipio> builder)
    {
        builder.ToTable("municipio");

        builder.Property(p => p.Id)
            .IsRequired();
        
        builder.Property(p => p.Nombre)
            .HasMaxLength(50)
            .IsRequired();
    
        builder.HasOne(p=> p.Departamento)
            .WithMany(p => p.Municipios)
            .HasForeignKey(p=>p.DepartamentoId);
    }

}
