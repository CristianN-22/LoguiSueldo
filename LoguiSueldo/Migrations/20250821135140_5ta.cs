using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoguiSueldo.Migrations
{
    /// <inheritdoc />
    public partial class _5ta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpresasOnline",
                columns: table => new
                {
                    EmpresaOnlineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioOnline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UltimoIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpresaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresasOnline", x => x.EmpresaOnlineID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpresasOnline");
        }
    }
}
