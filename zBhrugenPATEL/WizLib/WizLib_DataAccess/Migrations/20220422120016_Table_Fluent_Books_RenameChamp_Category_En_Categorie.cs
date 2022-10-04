using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class Table_Fluent_Books_RenameChamp_Category_En_Categorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Categories_CategoryId",
                table: "Fluent_Books");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Fluent_Books",
                newName: "CategorieId");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_Books_CategoryId",
                table: "Fluent_Books",
                newName: "IX_Fluent_Books_CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Categories_CategorieId",
                table: "Fluent_Books",
                column: "CategorieId",
                principalTable: "Fluent_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Categories_CategorieId",
                table: "Fluent_Books");

            migrationBuilder.RenameColumn(
                name: "CategorieId",
                table: "Fluent_Books",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_Books_CategorieId",
                table: "Fluent_Books",
                newName: "IX_Fluent_Books_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Categories_CategoryId",
                table: "Fluent_Books",
                column: "CategoryId",
                principalTable: "Fluent_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
