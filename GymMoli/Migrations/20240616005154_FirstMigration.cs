using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymMoli.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    ID_Clase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Clase = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripción = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Día = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Hora_Inicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    Hora_Fin = table.Column<TimeSpan>(type: "time", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.ID_Clase);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Fecha_Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Género = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teléfono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fecha_Registro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Entrenadores",
                columns: table => new
                {
                    ID_Entrenador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Teléfono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrenadores", x => x.ID_Entrenador);
                });

            migrationBuilder.CreateTable(
                name: "Membresias",
                columns: table => new
                {
                    ID_Membresía = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Membresía = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duración_Días = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membresias", x => x.ID_Membresía);
                });

            migrationBuilder.CreateTable(
                name: "Asistencias",
                columns: table => new
                {
                    ID_Asistencia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Clase = table.Column<int>(type: "int", nullable: false),
                    ID_Cliente = table.Column<int>(type: "int", nullable: false),
                    Fecha_Asistencia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencias", x => x.ID_Asistencia);
                    table.ForeignKey(
                        name: "FK_Asistencias_Clases_ID_Clase",
                        column: x => x.ID_Clase,
                        principalTable: "Clases",
                        principalColumn: "ID_Clase",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencias_Clientes_ID_Cliente",
                        column: x => x.ID_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "ID_Cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clases_Entrenadores",
                columns: table => new
                {
                    ID_Clase_Entrenador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Clase = table.Column<int>(type: "int", nullable: false),
                    ID_Entrenador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases_Entrenadores", x => x.ID_Clase_Entrenador);
                    table.ForeignKey(
                        name: "FK_Clases_Entrenadores_Clases_ID_Clase",
                        column: x => x.ID_Clase,
                        principalTable: "Clases",
                        principalColumn: "ID_Clase",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clases_Entrenadores_Entrenadores_ID_Entrenador",
                        column: x => x.ID_Entrenador,
                        principalTable: "Entrenadores",
                        principalColumn: "ID_Entrenador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    ID_Inscripción = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Cliente = table.Column<int>(type: "int", nullable: false),
                    ID_Membresía = table.Column<int>(type: "int", nullable: false),
                    Fecha_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.ID_Inscripción);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Clientes_ID_Cliente",
                        column: x => x.ID_Cliente,
                        principalTable: "Clientes",
                        principalColumn: "ID_Cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Membresias_ID_Membresía",
                        column: x => x.ID_Membresía,
                        principalTable: "Membresias",
                        principalColumn: "ID_Membresía",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_ID_Clase",
                table: "Asistencias",
                column: "ID_Clase");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencias_ID_Cliente",
                table: "Asistencias",
                column: "ID_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_Entrenadores_ID_Clase",
                table: "Clases_Entrenadores",
                column: "ID_Clase");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_Entrenadores_ID_Entrenador",
                table: "Clases_Entrenadores",
                column: "ID_Entrenador");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ID_Cliente",
                table: "Inscripciones",
                column: "ID_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ID_Membresía",
                table: "Inscripciones",
                column: "ID_Membresía");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencias");

            migrationBuilder.DropTable(
                name: "Clases_Entrenadores");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "Entrenadores");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Membresias");
        }
    }
}
