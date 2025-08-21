using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoguiSueldo.Migrations
{
    /// <inheritdoc />
    public partial class _4ta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpresaID",
                table: "Provincias");

            migrationBuilder.DropColumn(
                name: "EmpresaID",
                table: "Localidades");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaID",
                table: "Provincias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaID",
                table: "Localidades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
