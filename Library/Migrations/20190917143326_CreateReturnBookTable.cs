using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class CreateReturnBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReturnBooks",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    Barcode = table.Column<string>(nullable: false),
                    BookId = table.Column<int>(nullable: true),
                    ReturnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnBooks", x => new { x.StudentId, x.Barcode });
                    table.ForeignKey(
                        name: "FK_ReturnBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReturnBooks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReturnBooks_BookId",
                table: "ReturnBooks",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReturnBooks");
        }
    }
}
