using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "curso_escolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Año_Incio = table.Column<short>(type: "YEAR(4)", nullable: false),
                    Año_Fin = table.Column<short>(type: "YEAR(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso_escolar", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoAsignatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAsignatura", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nif = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha_Nacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    IdGenero = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_persona_Genero_IdGenero",
                        column: x => x.IdGenero,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Id_Departamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesor_Departamento_Id_Departamento",
                        column: x => x.Id_Departamento,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profesor_persona_Id",
                        column: x => x.Id,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "asignatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creditos = table.Column<float>(type: "float", nullable: false),
                    IdTipoAsignatura = table.Column<int>(type: "int", nullable: false),
                    Curso = table.Column<int>(type: "int", nullable: false),
                    Cuatrimestre = table.Column<int>(type: "int", nullable: false),
                    Id_Profesor = table.Column<int>(type: "int", nullable: true),
                    Id_Grado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_asignatura_Profesor_Id_Profesor",
                        column: x => x.Id_Profesor,
                        principalTable: "Profesor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_asignatura_TipoAsignatura_IdTipoAsignatura",
                        column: x => x.IdTipoAsignatura,
                        principalTable: "TipoAsignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_asignatura_grado_Id_Grado",
                        column: x => x.Id_Grado,
                        principalTable: "grado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AlumnoMatriculaAsignatura",
                columns: table => new
                {
                    Id_Alumno = table.Column<int>(type: "int", nullable: false),
                    Id_Asignatura = table.Column<int>(type: "int", nullable: false),
                    ID_curso_escolar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoMatriculaAsignatura", x => new { x.ID_curso_escolar, x.Id_Alumno, x.Id_Asignatura });
                    table.ForeignKey(
                        name: "FK_AlumnoMatriculaAsignatura_asignatura_Id_Asignatura",
                        column: x => x.Id_Asignatura,
                        principalTable: "asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoMatriculaAsignatura_curso_escolar_ID_curso_escolar",
                        column: x => x.ID_curso_escolar,
                        principalTable: "curso_escolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoMatriculaAsignatura_persona_Id_Alumno",
                        column: x => x.Id_Alumno,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoMatriculaAsignatura_Id_Alumno",
                table: "AlumnoMatriculaAsignatura",
                column: "Id_Alumno");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoMatriculaAsignatura_Id_Asignatura",
                table: "AlumnoMatriculaAsignatura",
                column: "Id_Asignatura");

            migrationBuilder.CreateIndex(
                name: "IX_asignatura_Id_Grado",
                table: "asignatura",
                column: "Id_Grado");

            migrationBuilder.CreateIndex(
                name: "IX_asignatura_Id_Profesor",
                table: "asignatura",
                column: "Id_Profesor");

            migrationBuilder.CreateIndex(
                name: "IX_asignatura_IdTipoAsignatura",
                table: "asignatura",
                column: "IdTipoAsignatura");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdGenero",
                table: "persona",
                column: "IdGenero");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdRol",
                table: "persona",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_Id_Departamento",
                table: "Profesor",
                column: "Id_Departamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoMatriculaAsignatura");

            migrationBuilder.DropTable(
                name: "asignatura");

            migrationBuilder.DropTable(
                name: "curso_escolar");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "TipoAsignatura");

            migrationBuilder.DropTable(
                name: "grado");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
