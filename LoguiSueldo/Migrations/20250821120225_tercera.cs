using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoguiSueldo.Migrations
{
    /// <inheritdoc />
    public partial class tercera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreFantasia",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PersonaConsumidorFinal",
                table: "Personas");

            migrationBuilder.RenameColumn(
                name: "TipoContribuyenteID",
                table: "Personas",
                newName: "ProvinciaID");

            migrationBuilder.RenameColumn(
                name: "EmpresaIDLoguiGestion",
                table: "Empresas",
                newName: "Cuit");

            migrationBuilder.AddColumn<int>(
                name: "CodPostal",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaisID",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodPostal",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PaisID",
                table: "Personas");

            migrationBuilder.RenameColumn(
                name: "ProvinciaID",
                table: "Personas",
                newName: "TipoContribuyenteID");

            migrationBuilder.RenameColumn(
                name: "Cuit",
                table: "Empresas",
                newName: "EmpresaIDLoguiGestion");

            migrationBuilder.AddColumn<string>(
                name: "NombreFantasia",
                table: "Personas",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "PersonaConsumidorFinal",
                table: "Personas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
