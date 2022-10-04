using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class rename_GenresTable_usingAnnotaion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_table_Genres",
                table: "table_Genres");

            migrationBuilder.RenameTable(
                name: "table_Genres",
                newName: "tb_genres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_genres",
                table: "tb_genres",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_genres",
                table: "tb_genres");

            migrationBuilder.RenameTable(
                name: "tb_genres",
                newName: "table_Genres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_table_Genres",
                table: "table_Genres",
                column: "GenreId");
        }
    }
}
