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

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("empleado");

        builder.Property(p => p.Id)
            .IsRequired();
        builder.Property(p => p.IdEmp)
            .HasMaxLength(15)
            .IsRequired();
        builder.HasIndex(p=> p.IdEmp)
            .IsUnique();
    
        builder.Property(p => p.Nombre)
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(p => p.FechaIngreso)
            .IsRequired();

        builder.HasOne(p=> p.Cargo)
            .WithMany(p => p.Empleados)
            .HasForeignKey(p=>p.CargoId);
            
        builder.HasOne(p=> p.Municipio)
            .WithMany(p => p.Empleados)
            .HasForeignKey(p=>p.MunicipioId);

    }
        

}
