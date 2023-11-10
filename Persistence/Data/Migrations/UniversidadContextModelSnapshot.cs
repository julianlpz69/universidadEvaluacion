﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(UniversidadContext))]
    partial class UniversidadContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AsignaturaCursoEscolar", b =>
                {
                    b.Property<int>("AsignaturasId")
                        .HasColumnType("int");

                    b.Property<int>("CursoEscolarsId")
                        .HasColumnType("int");

                    b.HasKey("AsignaturasId", "CursoEscolarsId");

                    b.HasIndex("CursoEscolarsId");

                    b.ToTable("AsignaturaCursoEscolar");
                });

            modelBuilder.Entity("AsignaturaPersona", b =>
                {
                    b.Property<int>("AsignaturasId")
                        .HasColumnType("int");

                    b.Property<int>("PersonasId")
                        .HasColumnType("int");

                    b.HasKey("AsignaturasId", "PersonasId");

                    b.HasIndex("PersonasId");

                    b.ToTable("AsignaturaPersona");
                });

            modelBuilder.Entity("CursoEscolarPersona", b =>
                {
                    b.Property<int>("CursoEscolarsId")
                        .HasColumnType("int");

                    b.Property<int>("PersonasId")
                        .HasColumnType("int");

                    b.HasKey("CursoEscolarsId", "PersonasId");

                    b.HasIndex("PersonasId");

                    b.ToTable("CursoEscolarPersona");
                });

            modelBuilder.Entity("Domain.Entities.AlumnoMatriculaAsignatura", b =>
                {
                    b.Property<int>("ID_curso_escolar")
                        .HasColumnType("int");

                    b.Property<int>("Id_Alumno")
                        .HasColumnType("int");

                    b.Property<int>("Id_Asignatura")
                        .HasColumnType("int");

                    b.HasKey("ID_curso_escolar", "Id_Alumno", "Id_Asignatura");

                    b.HasIndex("Id_Alumno");

                    b.HasIndex("Id_Asignatura");

                    b.ToTable("AlumnoMatriculaAsignatura", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Asignatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Creditos")
                        .HasColumnType("float");

                    b.Property<int>("Cuatrimestre")
                        .HasColumnType("int");

                    b.Property<int>("Curso")
                        .HasColumnType("int");

                    b.Property<int>("Id_Grado")
                        .HasColumnType("int");

                    b.Property<int>("Id_Profesor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Id_Grado");

                    b.HasIndex("Id_Profesor");

                    b.ToTable("asignatura", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CursoEscolar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<short>("Año_Fin")
                        .HasColumnType("YEAR(4)");

                    b.Property<short>("Año_Incio")
                        .HasColumnType("YEAR(4)");

                    b.HasKey("Id");

                    b.ToTable("curso_escolar", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Departamento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Grado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("grado", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateOnly>("Fecha_Nacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("persona", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("Id_Departamento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Profesor", (string)null);
                });

            modelBuilder.Entity("AsignaturaCursoEscolar", b =>
                {
                    b.HasOne("Domain.Entities.Asignatura", null)
                        .WithMany()
                        .HasForeignKey("AsignaturasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CursoEscolar", null)
                        .WithMany()
                        .HasForeignKey("CursoEscolarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AsignaturaPersona", b =>
                {
                    b.HasOne("Domain.Entities.Asignatura", null)
                        .WithMany()
                        .HasForeignKey("AsignaturasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Persona", null)
                        .WithMany()
                        .HasForeignKey("PersonasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CursoEscolarPersona", b =>
                {
                    b.HasOne("Domain.Entities.CursoEscolar", null)
                        .WithMany()
                        .HasForeignKey("CursoEscolarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Persona", null)
                        .WithMany()
                        .HasForeignKey("PersonasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.AlumnoMatriculaAsignatura", b =>
                {
                    b.HasOne("Domain.Entities.CursoEscolar", "CursoEscolar")
                        .WithMany("Alumno_Se_Matricula_Asignaturas")
                        .HasForeignKey("ID_curso_escolar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Persona", "Persona")
                        .WithMany("Alumno_Se_Matricula_Asignaturas")
                        .HasForeignKey("Id_Alumno")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Asignatura", "Asignatura")
                        .WithMany("Alumno_Se_Matricula_Asignaturas")
                        .HasForeignKey("Id_Asignatura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asignatura");

                    b.Navigation("CursoEscolar");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Domain.Entities.Asignatura", b =>
                {
                    b.HasOne("Domain.Entities.Grado", "Grado")
                        .WithMany("Asignaturas")
                        .HasForeignKey("Id_Grado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Profesor", "Profesor")
                        .WithMany("Asignaturas")
                        .HasForeignKey("Id_Profesor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grado");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.HasOne("Domain.Entities.Profesor", "Profesor")
                        .WithOne("Persona")
                        .HasForeignKey("Domain.Entities.Persona", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("Domain.Entities.Profesor", b =>
                {
                    b.HasOne("Domain.Entities.Departamento", "Departamento")
                        .WithMany("Profesores")
                        .HasForeignKey("DepartamentoId");

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Domain.Entities.Asignatura", b =>
                {
                    b.Navigation("Alumno_Se_Matricula_Asignaturas");
                });

            modelBuilder.Entity("Domain.Entities.CursoEscolar", b =>
                {
                    b.Navigation("Alumno_Se_Matricula_Asignaturas");
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Navigation("Profesores");
                });

            modelBuilder.Entity("Domain.Entities.Grado", b =>
                {
                    b.Navigation("Asignaturas");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Navigation("Alumno_Se_Matricula_Asignaturas");
                });

            modelBuilder.Entity("Domain.Entities.Profesor", b =>
                {
                    b.Navigation("Asignaturas");

                    b.Navigation("Persona");
                });
#pragma warning restore 612, 618
        }
    }
}