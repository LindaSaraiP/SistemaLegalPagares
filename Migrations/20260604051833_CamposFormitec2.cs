using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLegalPagares.Migrations
{
    /// <inheritdoc />
    public partial class CamposFormitec2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Beneficiario",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DomicilioDeudor",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InteresMoratorio",
                table: "Pagares",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LugarPagoPagare",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PoblacionDeudor",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerieDesde",
                table: "Pagares",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerieHasta",
                table: "Pagares",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beneficiario",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "DomicilioDeudor",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "InteresMoratorio",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "LugarPagoPagare",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "PoblacionDeudor",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "SerieDesde",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "SerieHasta",
                table: "Pagares");
        }
    }
}
