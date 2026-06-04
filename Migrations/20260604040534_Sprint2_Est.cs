using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLegalPagares.Migrations
{
    /// <inheritdoc />
    public partial class Sprint2_Est : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagares_Expediente_ExpedienteId",
                table: "Pagares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expediente",
                table: "Expediente");

            migrationBuilder.RenameTable(
                name: "Expediente",
                newName: "Expedientes");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroExpediente",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NombreSuscriptor",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NombreBeneficiario",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Monto",
                table: "Pagares",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "LugarSuscripcion",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LugarPago",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirmaSuscriptor",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaSuscripcion",
                table: "Pagares",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaPago",
                table: "Pagares",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ExpedienteId",
                table: "Pagares",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Acreedor",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaExpedicion",
                table: "Pagares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVencimiento",
                table: "Pagares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirmaBase64",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LugarExpedicion",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MontoLetra",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MontoTotal",
                table: "Pagares",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "NumeroPagare",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextoLegal",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expedientes",
                table: "Expedientes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Deudores",
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
                    table.PrimaryKey("PK_Deudores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubPagares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PagareId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubPagares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubPagares_Pagares_PagareId",
                        column: x => x.PagareId,
                        principalTable: "Pagares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagareDeudores",
                columns: table => new
                {
                    PagareId = table.Column<int>(type: "int", nullable: false),
                    DeudorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagareDeudores", x => new { x.PagareId, x.DeudorId });
                    table.ForeignKey(
                        name: "FK_PagareDeudores_Deudores_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "Deudores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagareDeudores_Pagares_PagareId",
                        column: x => x.PagareId,
                        principalTable: "Pagares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PagareDeudores_DeudorId",
                table: "PagareDeudores",
                column: "DeudorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubPagares_PagareId",
                table: "SubPagares",
                column: "PagareId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagares_Expedientes_ExpedienteId",
                table: "Pagares",
                column: "ExpedienteId",
                principalTable: "Expedientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pagares_Expedientes_ExpedienteId",
                table: "Pagares");

            migrationBuilder.DropTable(
                name: "PagareDeudores");

            migrationBuilder.DropTable(
                name: "SubPagares");

            migrationBuilder.DropTable(
                name: "Deudores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expedientes",
                table: "Expedientes");

            migrationBuilder.DropColumn(
                name: "Acreedor",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "FechaExpedicion",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "FechaVencimiento",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "FirmaBase64",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "LugarExpedicion",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "MontoLetra",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "MontoTotal",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "NumeroPagare",
                table: "Pagares");

            migrationBuilder.DropColumn(
                name: "TextoLegal",
                table: "Pagares");

            migrationBuilder.RenameTable(
                name: "Expedientes",
                newName: "Expediente");

            migrationBuilder.AlterColumn<string>(
                name: "NumeroExpediente",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreSuscriptor",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreBeneficiario",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Monto",
                table: "Pagares",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LugarSuscripcion",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LugarPago",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirmaSuscriptor",
                table: "Pagares",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaSuscripcion",
                table: "Pagares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaPago",
                table: "Pagares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExpedienteId",
                table: "Pagares",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expediente",
                table: "Expediente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagares_Expediente_ExpedienteId",
                table: "Pagares",
                column: "ExpedienteId",
                principalTable: "Expediente",
                principalColumn: "Id");
        }
    }
}
