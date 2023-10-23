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

public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("estado");

        builder.Property(p => p.Id)
            .IsRequired();
        builder.Property(p => p.Codigo)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.HasOne(p=> p.TipoEstado)
            .WithMany(p => p.Estados)
            .HasForeignKey(p=>p.TipoEstadoId);

    }
        

}
