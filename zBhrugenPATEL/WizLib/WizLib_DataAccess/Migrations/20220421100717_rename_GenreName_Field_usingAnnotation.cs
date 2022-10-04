using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class rename_GenreName_Field_usingAnnotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "tb_genres",
                newName: "MyNameColumn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyNameColumn",
                table: "tb_genres",
                newName: "GenreName");
        }
    }
}
