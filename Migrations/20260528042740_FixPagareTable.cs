using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLegalPagares.Migrations
{
    /// <inheritdoc />
    public partial class FixPagareTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroExpediente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NombreBeneficiario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreSuscriptor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LugarPago = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LugarSuscripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaSuscripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirmaSuscriptor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagare", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagare");
        }
    }
}
