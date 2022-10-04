using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class Fluent_Book_A_PlusieursPages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_PagesDeLivre_Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre",
                column: "Fluent_BookBook_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_PagesDeLivre_Fluent_Books_Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre",
                column: "Fluent_BookBook_Id",
                principalTable: "Fluent_Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_PagesDeLivre_Fluent_Books_Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_PagesDeLivre_Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre");

            migrationBuilder.DropColumn(
                name: "Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre");
        }
    }
}
