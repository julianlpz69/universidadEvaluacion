using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class PRimeraMigracion : Migration
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
                name: "Profesor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Departamento = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesor_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id");
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
                    Curso = table.Column<int>(type: "int", nullable: false),
                    Cuatrimestre = table.Column<int>(type: "int", nullable: false),
                    Id_Profesor = table.Column<int>(type: "int", nullable: false),
                    Id_Grado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_asignatura_Profesor_Id_Profesor",
                        column: x => x.Id_Profesor,
                        principalTable: "Profesor",
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
                name: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
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
                    Telefono = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha_Nacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_persona_Profesor_Id",
                        column: x => x.Id,
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AsignaturaCursoEscolar",
                columns: table => new
                {
                    AsignaturasId = table.Column<int>(type: "int", nullable: false),
                    CursoEscolarsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignaturaCursoEscolar", x => new { x.AsignaturasId, x.CursoEscolarsId });
                    table.ForeignKey(
                        name: "FK_AsignaturaCursoEscolar_asignatura_AsignaturasId",
                        column: x => x.AsignaturasId,
                        principalTable: "asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignaturaCursoEscolar_curso_escolar_CursoEscolarsId",
                        column: x => x.CursoEscolarsId,
                        principalTable: "curso_escolar",
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

            migrationBuilder.CreateTable(
                name: "AsignaturaPersona",
                columns: table => new
                {
                    AsignaturasId = table.Column<int>(type: "int", nullable: false),
                    PersonasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignaturaPersona", x => new { x.AsignaturasId, x.PersonasId });
                    table.ForeignKey(
                        name: "FK_AsignaturaPersona_asignatura_AsignaturasId",
                        column: x => x.AsignaturasId,
                        principalTable: "asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignaturaPersona_persona_PersonasId",
                        column: x => x.PersonasId,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CursoEscolarPersona",
                columns: table => new
                {
                    CursoEscolarsId = table.Column<int>(type: "int", nullable: false),
                    PersonasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoEscolarPersona", x => new { x.CursoEscolarsId, x.PersonasId });
                    table.ForeignKey(
                        name: "FK_CursoEscolarPersona_curso_escolar_CursoEscolarsId",
                        column: x => x.CursoEscolarsId,
                        principalTable: "curso_escolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoEscolarPersona_persona_PersonasId",
                        column: x => x.PersonasId,
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
                name: "IX_AsignaturaCursoEscolar_CursoEscolarsId",
                table: "AsignaturaCursoEscolar",
                column: "CursoEscolarsId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaPersona_PersonasId",
                table: "AsignaturaPersona",
                column: "PersonasId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoEscolarPersona_PersonasId",
                table: "CursoEscolarPersona",
                column: "PersonasId");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_DepartamentoId",
                table: "Profesor",
                column: "DepartamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoMatriculaAsignatura");

            migrationBuilder.DropTable(
                name: "AsignaturaCursoEscolar");

            migrationBuilder.DropTable(
                name: "AsignaturaPersona");

            migrationBuilder.DropTable(
                name: "CursoEscolarPersona");

            migrationBuilder.DropTable(
                name: "asignatura");

            migrationBuilder.DropTable(
                name: "curso_escolar");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "grado");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
