using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoProgramadoLenguajes2024.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExpedientePaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "MedicamentosPacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMedicamento = table.Column<int>(type: "int", nullable: false),
                    CedulaPaciente = table.Column<int>(type: "int", nullable: false),
                    NumeroColegiadoMedico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicamentosPacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicamentosPacientes_Medicamento_IdMedicamento",
                        column: x => x.IdMedicamento,
                        principalTable: "Medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicamentosPacientes_MedicoTratantes_NumeroColegiadoMedico",
                        column: x => x.NumeroColegiadoMedico,
                        principalTable: "MedicoTratantes",
                        principalColumn: "NumeroColegiado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicamentosPacientes_Paciente_CedulaPaciente",
                        column: x => x.CedulaPaciente,
                        principalTable: "Paciente",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                name: "PadecimientosPacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPadecimiento = table.Column<int>(type: "int", nullable: false),
                    CedulaPaciente = table.Column<int>(type: "int", nullable: false),
                    NumeroColegiadoMedico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PadecimientosPacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PadecimientosPacientes_MedicoTratantes_NumeroColegiadoMedico",
                        column: x => x.NumeroColegiadoMedico,
                        principalTable: "MedicoTratantes",
                        principalColumn: "NumeroColegiado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PadecimientosPacientes_Paciente_CedulaPaciente",
                        column: x => x.CedulaPaciente,
                        principalTable: "Paciente",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PadecimientosPacientes_Padecimiento_IdPadecimiento",
                        column: x => x.IdPadecimiento,
                        principalTable: "Padecimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TratamientosPacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTratamiento = table.Column<int>(type: "int", nullable: false),
                    CedulaPaciente = table.Column<int>(type: "int", nullable: false),
                    NumeroColegiadoMedico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamientosPacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamientosPacientes_MedicoTratantes_NumeroColegiadoMedico",
                        column: x => x.NumeroColegiadoMedico,
                        principalTable: "MedicoTratantes",
                        principalColumn: "NumeroColegiado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TratamientosPacientes_Paciente_CedulaPaciente",
                        column: x => x.CedulaPaciente,
                        principalTable: "Paciente",
                        principalColumn: "Cedula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TratamientosPacientes_Tratamiento_IdTratamiento",
                        column: x => x.IdTratamiento,
                        principalTable: "Tratamiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examen_CedulaPaciente",
                table: "Examen",
                column: "CedulaPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Examen_NumeroColegiadoMedico",
                table: "Examen",
                column: "NumeroColegiadoMedico");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentosPacientes_CedulaPaciente",
                table: "MedicamentosPacientes",
                column: "CedulaPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentosPacientes_IdMedicamento",
                table: "MedicamentosPacientes",
                column: "IdMedicamento");

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentosPacientes_NumeroColegiadoMedico",
                table: "MedicamentosPacientes",
                column: "NumeroColegiadoMedico");

            migrationBuilder.CreateIndex(
                name: "IX_NotaMedica_CedulaPaciente",
                table: "NotaMedica",
                column: "CedulaPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_NotaMedica_NumeroColegiadoMedico",
                table: "NotaMedica",
                column: "NumeroColegiadoMedico");

            migrationBuilder.CreateIndex(
                name: "IX_PadecimientosPacientes_CedulaPaciente",
                table: "PadecimientosPacientes",
                column: "CedulaPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_PadecimientosPacientes_IdPadecimiento",
                table: "PadecimientosPacientes",
                column: "IdPadecimiento");

            migrationBuilder.CreateIndex(
                name: "IX_PadecimientosPacientes_NumeroColegiadoMedico",
                table: "PadecimientosPacientes",
                column: "NumeroColegiadoMedico");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientosPacientes_CedulaPaciente",
                table: "TratamientosPacientes",
                column: "CedulaPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientosPacientes_IdTratamiento",
                table: "TratamientosPacientes",
                column: "IdTratamiento");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientosPacientes_NumeroColegiadoMedico",
                table: "TratamientosPacientes",
                column: "NumeroColegiadoMedico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examen");

            migrationBuilder.DropTable(
                name: "MedicamentosPacientes");

            migrationBuilder.DropTable(
                name: "NotaMedica");

            migrationBuilder.DropTable(
                name: "PadecimientosPacientes");

            migrationBuilder.DropTable(
                name: "TratamientosPacientes");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
