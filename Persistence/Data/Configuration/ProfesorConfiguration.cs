using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
{
    public void Configure(EntityTypeBuilder<Profesor> builder){

        builder.ToTable("Profesor");


        builder.HasOne(p => p.Departamento)
            .WithMany(p => p.Profesores)
            .HasForeignKey(p => p.Id_Departamento);

       
    }
}
}