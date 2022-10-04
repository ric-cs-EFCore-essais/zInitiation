using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class Fluent_Page_FK_NOT_NULL_Et_Renamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_PagesDeLivre_Fluent_Books_Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre");

            migrationBuilder.AlterColumn<int>(
                name: "Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_PagesDeLivre_Fluent_Books_Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre",
                column: "Fluent_BookBook_Id",
                principalTable: "Fluent_Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_PagesDeLivre_Fluent_Books_Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre");

            migrationBuilder.AlterColumn<int>(
                name: "Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_PagesDeLivre_Fluent_Books_Fluent_BookBook_Id",
                table: "Fluent_PagesDeLivre",
                column: "Fluent_BookBook_Id",
                principalTable: "Fluent_Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
