using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class Table_Fluent_Books_Ajout_Dune_FK_NotNULL_MyPublisher__Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyPublisher__Id",
                table: "Fluent_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_MyPublisher__Id",
                table: "Fluent_Books",
                column: "MyPublisher__Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Publishers_MyPublisher__Id",
                table: "Fluent_Books",
                column: "MyPublisher__Id",
                principalTable: "Fluent_Publishers",
                principalColumn: "Fluent_PublisherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Publishers_MyPublisher__Id",
                table: "Fluent_Books");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Books_MyPublisher__Id",
                table: "Fluent_Books");

            migrationBuilder.DropColumn(
                name: "MyPublisher__Id",
                table: "Fluent_Books");
        }
    }
}
