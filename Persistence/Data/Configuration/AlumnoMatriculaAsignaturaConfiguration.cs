using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
public class AlumnoMatriculaAsignaturaConfiguration : IEntityTypeConfiguration<AlumnoMatriculaAsignatura>
{
    public void Configure(EntityTypeBuilder<AlumnoMatriculaAsignatura> builder){

        builder.ToTable("AlumnoMatriculaAsignatura");


            builder
                .HasKey(urrt => new { urrt.ID_curso_escolar, urrt.Id_Alumno, urrt.Id_Asignatura });

            builder
                .HasOne(urrt => urrt.CursoEscolar)
                .WithMany(u => u.Alumno_Se_Matricula_Asignaturas)
                .HasForeignKey(urrt => urrt.ID_curso_escolar);

            builder
                .HasOne(urrt => urrt.Asignatura)
                .WithMany(r => r.Alumno_Se_Matricula_Asignaturas)
                .HasForeignKey(urrt => urrt.Id_Asignatura);

            builder
                .HasOne(urrt => urrt.Persona)
                .WithMany(rt => rt.Alumno_Se_Matricula_Asignaturas)
                .HasForeignKey(urrt => urrt.Id_Alumno);


    }
}
}