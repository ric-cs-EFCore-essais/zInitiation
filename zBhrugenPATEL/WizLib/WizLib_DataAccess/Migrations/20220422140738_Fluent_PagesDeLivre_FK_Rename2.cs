using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class Fluent_PagesDeLivre_FK_Rename2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_PagesDeLivre_Fluent_Books_Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre");

            migrationBuilder.RenameColumn(
                name: "Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre",
                newName: "Fluent_Book_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_PagesDeLivre_Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre",
                newName: "IX_Fluent_PagesDeLivre_Fluent_Book_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_PagesDeLivre_Fluent_Books_Fluent_Book_Id",
                table: "Fluent_PagesDeLivre",
                column: "Fluent_Book_Id",
                principalTable: "Fluent_Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_PagesDeLivre_Fluent_Books_Fluent_Book_Id",
                table: "Fluent_PagesDeLivre");

            migrationBuilder.RenameColumn(
                name: "Fluent_Book_Id",
                table: "Fluent_PagesDeLivre",
                newName: "Fluent_BookBook_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_PagesDeLivre_Fluent_Book_Id",
                table: "Fluent_PagesDeLivre",
                newName: "IX_Fluent_PagesDeLivre_Fluent_BookBook_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_PagesDeLivre_Fluent_Books_Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre",
                column: "Fluent_BookBook_Id",
                principalTable: "Fluent_Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
