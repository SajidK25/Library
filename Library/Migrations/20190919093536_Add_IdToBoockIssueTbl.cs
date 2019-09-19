using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class Add_IdToBoockIssueTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnBooks_Books_BookId",
                table: "ReturnBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookIssues",
                table: "BookIssues");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "ReturnBooks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "BookIssues",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookIssues",
                table: "BookIssues",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssues_StudentId",
                table: "BookIssues",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnBooks_Books_BookId",
                table: "ReturnBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReturnBooks_Books_BookId",
                table: "ReturnBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookIssues",
                table: "BookIssues");

            migrationBuilder.DropIndex(
                name: "IX_BookIssues_StudentId",
                table: "BookIssues");

            migrationBuilder.DropColumn(
                name: "id",
                table: "BookIssues");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "ReturnBooks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookIssues",
                table: "BookIssues",
                columns: new[] { "StudentId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnBooks_Books_BookId",
                table: "ReturnBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
