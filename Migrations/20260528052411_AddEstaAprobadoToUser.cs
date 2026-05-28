using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLegalPagares.Migrations
{
    /// <inheritdoc />
    public partial class AddEstaAprobadoToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pagare",
                table: "Pagare");

            migrationBuilder.RenameTable(
                name: "Pagare",
                newName: "Pagares");

            migrationBuilder.AddColumn<bool>(
                name: "EstaAprobado",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pagares",
                table: "Pagares",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pagares",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "EstaAprobado",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Pagares",
                newName: "Pagare");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pagare",
                table: "Pagare",
                column: "Id");
        }
    }
}
