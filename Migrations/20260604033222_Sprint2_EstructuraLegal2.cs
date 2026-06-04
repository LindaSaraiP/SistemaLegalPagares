using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLegalPagares.Migrations
{
    /// <inheritdoc />
    public partial class Sprint2_EstructuraLegal2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpedienteId",
                table: "Pagares",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Expediente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroExpediente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CURP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expediente", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagares_ExpedienteId",
                table: "Pagares",
                column: "ExpedienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagares_Expediente_ExpedienteId",
                table: "Pagares",
                column: "ExpedienteId",
                principalTable: "Expediente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagares_Expediente_ExpedienteId",
                table: "Pagares");

            migrationBuilder.DropTable(
                name: "Expediente");

            migrationBuilder.DropIndex(
                name: "IX_Pagares_ExpedienteId",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "ExpedienteId",
                table: "Pagares");
        }
    }
}
