using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder){

        builder.ToTable("persona");

        builder.Property(p => p.Nif)
        .IsRequired()
        .HasMaxLength(9);

        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(25);

        builder.Property(p => p.Apellido1)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Apellido2)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Ciudad)
        .IsRequired()
        .HasMaxLength(25);

        builder.Property(p => p.Direccion)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Telefono)
        .HasMaxLength(9);

        builder.Property(p => p.Fecha_Nacimiento)
        .IsRequired()
        .HasColumnType("date");



        builder.HasOne(p => p.Profesor)
                .WithOne(p => p.Persona)
                 .HasForeignKey<Profesor>(d => d.Id);
        

       builder.HasOne(p => p.Genero)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdGenero);

        builder.HasOne(p => p.Rol)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdRol);

     
        
    }
}
}



