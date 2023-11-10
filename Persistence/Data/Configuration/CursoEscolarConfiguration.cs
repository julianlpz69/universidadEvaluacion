using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
public class CursoEscolarConfiguration : IEntityTypeConfiguration<CursoEscolar>
{
    public void Configure(EntityTypeBuilder<CursoEscolar> builder){

        builder.ToTable("curso_escolar");

       builder.Property(u => u.Año_Fin).HasColumnType("YEAR(4)");
       builder.Property(u => u.Año_Incio).HasColumnType("YEAR(4)");

    }
}
}