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

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("departamento");

        builder.Property(p => p.Id)
            .IsRequired();
        
        builder.Property(p => p.Nombre)
            .HasMaxLength(15)
            .IsRequired();

        builder.HasOne(p=> p.Pais)
            .WithMany(p => p.Departamentos)
            .HasForeignKey(p=>p.PaisId);
    }

}
