using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLegalPagares.Migrations
{
    /// <inheritdoc />
    public partial class AgregarClientesYRelaciones2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PagareDeudores_Deudores_DeudorId",
                table: "PagareDeudores");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagares_Expedientes_ExpedienteId",
                table: "Pagares");

            migrationBuilder.AlterColumn<int>(
                name: "SerieHasta",
                table: "Pagares",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SerieDesde",
                table: "Pagares",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Expedientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Poblacion",
                table: "Deudores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CURP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_ClienteId",
                table: "Expedientes",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expedientes_Clientes_ClienteId",
                table: "Expedientes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PagareDeudores_Deudores_DeudorId",
                table: "PagareDeudores",
                column: "DeudorId",
                principalTable: "Deudores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagares_Expedientes_ExpedienteId",
                table: "Pagares",
                column: "ExpedienteId",
                principalTable: "Expedientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expedientes_Clientes_ClienteId",
                table: "Expedientes");

            migrationBuilder.DropForeignKey(
                name: "FK_PagareDeudores_Deudores_DeudorId",
                table: "PagareDeudores");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagares_Expedientes_ExpedienteId",
                table: "Pagares");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Expedientes_ClienteId",
                table: "Expedientes");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Expedientes");

            migrationBuilder.DropColumn(
                name: "Poblacion",
                table: "Deudores");

            migrationBuilder.AlterColumn<int>(
                name: "SerieHasta",
                table: "Pagares",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SerieDesde",
                table: "Pagares",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PagareDeudores_Deudores_DeudorId",
                table: "PagareDeudores",
                column: "DeudorId",
                principalTable: "Deudores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagares_Expedientes_ExpedienteId",
                table: "Pagares",
                column: "ExpedienteId",
                principalTable: "Expedientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
