using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceApplication.INFRASTRUCTURE.Migrations
{
    public partial class AddInvoiceDetailsList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacturaIdFactura",
                table: "DetaliiFacturi",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
