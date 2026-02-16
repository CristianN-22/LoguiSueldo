using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoguiSueldo.Migrations
{
    /// <inheritdoc />
    public partial class inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoContribuyenteID",
                table: "Empresas");

            migrationBuilder.CreateTable(
                name: "ClientesLogui",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoContribuyenteID = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoID = table.Column<int>(type: "int", nullable: false),
                    NroTipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesLogui", x => x.ClienteID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientesLogui");

            migrationBuilder.AddColumn<int>(
                name: "TipoContribuyenteID",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
