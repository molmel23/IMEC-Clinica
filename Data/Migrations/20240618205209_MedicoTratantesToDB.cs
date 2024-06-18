using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoProgramadoLenguajes2024.Data.Migrations
{
    /// <inheritdoc />
    public partial class MedicoTratantesToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicoTratantes",
                columns: table => new
                {
                    NumeroColegiado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoTratantes", x => x.NumeroColegiado);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades_MedicoTratantes",
                columns: table => new
                {
                    MedicoTratanteId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades_MedicoTratantes", x => new { x.MedicoTratanteId, x.EspecialidadId });
                    table.ForeignKey(
                        name: "FK_Especialidades_MedicoTratantes_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Especialidades_MedicoTratantes_MedicoTratantes_MedicoTratanteId",
                        column: x => x.MedicoTratanteId,
                        principalTable: "MedicoTratantes",
                        principalColumn: "NumeroColegiado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_MedicoTratantes_EspecialidadId",
                table: "Especialidades_MedicoTratantes",
                column: "EspecialidadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Especialidades_MedicoTratantes");

            migrationBuilder.DropTable(
                name: "MedicoTratantes");
        }
    }
}
