using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceApplication.INFRASTRUCTURE.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetaliiFacturi",
                columns: table => new
                {
                    IdDetaliiFactura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLocatie = table.Column<int>(nullable: false),
                    IdFactura = table.Column<int>(nullable: false),
                    NumeProdus = table.Column<string>(maxLength: 200, nullable: true),
                    Cantitate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PretUnitar = table.Column<decimal>(type: "money", nullable: false),
                    Valoare = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetaliiFacturi", x => new { x.IdDetaliiFactura, x.IdLocatie });
                });

            migrationBuilder.CreateTable(
                name: "Facturi",
                columns: table => new
                {
                    IdFactura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLocatie = table.Column<int>(nullable: false),
                    NumarFactura = table.Column<string>(maxLength: 50, nullable: true),
                    DataFactura = table.Column<DateTime>(nullable: false),
                    NumeClient = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturi", x => new { x.IdFactura, x.IdLocatie });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetaliiFacturi");

            migrationBuilder.DropTable(
                name: "Facturi");
        }
    }
}
