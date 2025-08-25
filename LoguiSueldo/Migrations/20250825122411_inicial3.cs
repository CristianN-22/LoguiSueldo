using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoguiSueldo.Migrations
{
    /// <inheritdoc />
    public partial class inicial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoContribuyenteID",
                table: "ClientesLogui");

            migrationBuilder.CreateTable(
                name: "TipoDocumentos",
                columns: table => new
                {
                    TipoDocumentoID = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentos", x => x.TipoDocumentoID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_TipoDocumentoID",
                table: "Personas",
                column: "TipoDocumentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_TipoDocumentoID",
                table: "Empresas",
                column: "TipoDocumentoID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesLogui_TipoDocumentoID",
                table: "ClientesLogui",
                column: "TipoDocumentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesLogui_TipoDocumentos_TipoDocumentoID",
                table: "ClientesLogui",
                column: "TipoDocumentoID",
                principalTable: "TipoDocumentos",
                principalColumn: "TipoDocumentoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_TipoDocumentos_TipoDocumentoID",
                table: "Empresas",
                column: "TipoDocumentoID",
                principalTable: "TipoDocumentos",
                principalColumn: "TipoDocumentoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TipoDocumentos_TipoDocumentoID",
                table: "Personas",
                column: "TipoDocumentoID",
                principalTable: "TipoDocumentos",
                principalColumn: "TipoDocumentoID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientesLogui_TipoDocumentos_TipoDocumentoID",
                table: "ClientesLogui");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_TipoDocumentos_TipoDocumentoID",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TipoDocumentos_TipoDocumentoID",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "TipoDocumentos");

            migrationBuilder.DropIndex(
                name: "IX_Personas_TipoDocumentoID",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_TipoDocumentoID",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_ClientesLogui_TipoDocumentoID",
                table: "ClientesLogui");

            migrationBuilder.AddColumn<int>(
                name: "TipoContribuyenteID",
                table: "ClientesLogui",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
