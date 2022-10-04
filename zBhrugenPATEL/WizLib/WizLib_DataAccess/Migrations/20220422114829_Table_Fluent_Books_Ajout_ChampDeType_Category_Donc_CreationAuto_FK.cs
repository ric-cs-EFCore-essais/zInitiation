using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class Table_Fluent_Books_Ajout_ChampDeType_Category_Donc_CreationAuto_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Fluent_Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fluent_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_CategoryId",
                table: "Fluent_Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Categories_CategoryId",
                table: "Fluent_Books",
                column: "CategoryId",
                principalTable: "Fluent_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Categories_CategoryId",
                table: "Fluent_Books");

            migrationBuilder.DropTable(
                name: "Fluent_Categories");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Books_CategoryId",
                table: "Fluent_Books");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Fluent_Books");
        }
    }
}
