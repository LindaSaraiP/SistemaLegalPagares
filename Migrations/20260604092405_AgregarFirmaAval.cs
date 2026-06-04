using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLegalPagares.Migrations
{
    /// <inheritdoc />
    public partial class AgregarFirmaAval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirmaAvalBase64",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirmaAvalBase64",
                table: "Pagares");
        }
    }
}
