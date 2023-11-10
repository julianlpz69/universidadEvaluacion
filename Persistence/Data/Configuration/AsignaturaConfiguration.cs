using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class AsignaturaConfiguration : IEntityTypeConfiguration<Asignatura>
    {
        public void Configure(EntityTypeBuilder<Asignatura> builder){
    
            builder.ToTable("asignatura");
    
            builder.Property(e => e.Nombre)
                .HasMaxLength(100);

            builder.HasOne(p => p.Profesor)
                .WithMany(p => p.Asignaturas)
                .HasForeignKey(p => p.Id_Profesor);

            builder.HasOne(p => p.Grado)
                .WithMany(p => p.Asignaturas)
                .HasForeignKey(p => p.Id_Grado);
        }
    }
}