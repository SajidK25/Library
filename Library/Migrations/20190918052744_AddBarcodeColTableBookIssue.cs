using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class AddBarcodeColTableBookIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "BookIssues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "BookIssues");
        }
    }
}
