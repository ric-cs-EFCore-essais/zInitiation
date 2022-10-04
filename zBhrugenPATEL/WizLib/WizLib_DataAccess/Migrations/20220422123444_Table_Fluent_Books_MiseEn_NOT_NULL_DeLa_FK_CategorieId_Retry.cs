using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class Table_Fluent_Books_MiseEn_NOT_NULL_DeLa_FK_CategorieId_Retry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Categories_CategorieId",
                table: "Fluent_Books");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Fluent_Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Categories_CategorieId",
                table: "Fluent_Books",
                column: "CategorieId",
                principalTable: "Fluent_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Categories_CategorieId",
                table: "Fluent_Books");

            migrationBuilder.AlterColumn<int>(
                name: "CategorieId",
                table: "Fluent_Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Categories_CategorieId",
                table: "Fluent_Books",
                column: "CategorieId",
                principalTable: "Fluent_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
