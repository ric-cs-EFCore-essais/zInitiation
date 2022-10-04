using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class EmptyMigration_For_SqlInsertIntoCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Categ1')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Categ2')");
            migrationBuilder.Sql("INSERT INTO Categories (Name) VALUES ('Categ3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
