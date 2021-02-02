using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceApplication.INFRASTRUCTURE.Migrations
{
    public partial class RemoveFacturaDetaliiList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetaliiFacturi_Facturi_FacturaIdFactura",
                table: "DetaliiFacturi");

            migrationBuilder.DropIndex(
                name: "IX_DetaliiFacturi_FacturaIdFactura",
                table: "DetaliiFacturi");

            migrationBuilder.DropColumn(
                name: "FacturaIdFactura",
                table: "DetaliiFacturi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacturaIdFactura",
                table: "DetaliiFacturi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetaliiFacturi_FacturaIdFactura",
                table: "DetaliiFacturi",
                column: "FacturaIdFactura");

            migrationBuilder.AddForeignKey(
                name: "FK_DetaliiFacturi_Facturi_FacturaIdFactura",
                table: "DetaliiFacturi",
                column: "FacturaIdFactura",
                principalTable: "Facturi",
                principalColumn: "IdFactura",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
