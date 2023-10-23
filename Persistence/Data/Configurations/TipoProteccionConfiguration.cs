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

public class TipoProteccionConfiguration : IEntityTypeConfiguration<TipoProteccion>
{
    public void Configure(EntityTypeBuilder<TipoProteccion> builder)
    {
        builder.ToTable("tipoProteccion");

        builder.Property(p => p.Id)
            .IsRequired();
        
        builder.Property(p => p.Descripcion)
            .HasMaxLength(50)
            .IsRequired();
        builder.HasIndex(p => p.Descripcion)
            .IsUnique();

     
    }

}
