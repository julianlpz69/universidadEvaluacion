using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
{
    public void Configure(EntityTypeBuilder<Profesor> builder){

        builder.ToTable("Profesor");

        builder.HasOne(p => p.Persona)
            .WithOne(d => d.Profesor)
            .HasForeignKey<Persona>(d => d.Id);

    
    }
}
}