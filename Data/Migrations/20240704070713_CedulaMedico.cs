using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoProgramadoLenguajes2024.Data.Migrations
{
    /// <inheritdoc />
    public partial class CedulaMedico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cedula",
                table: "MedicoTratantes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "MedicoTratantes");
        }
    }
}
