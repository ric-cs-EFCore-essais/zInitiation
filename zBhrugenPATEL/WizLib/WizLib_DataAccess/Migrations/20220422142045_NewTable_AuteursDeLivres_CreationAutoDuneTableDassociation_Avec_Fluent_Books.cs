using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class NewTable_AuteursDeLivres_CreationAutoDuneTableDassociation_Avec_Fluent_Books : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fluent_AuteursDeLivres",
                columns: table => new
                {
                    A_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_AuteursDeLivres", x => x.A_Id);
                });

            migrationBuilder.CreateTable(
                name: "Fluent_AuthorFluent_Book",
                columns: table => new
                {
                    AuthorsA_Id = table.Column<int>(type: "int", nullable: false),
                    LivresBook_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_AuthorFluent_Book", x => new { x.AuthorsA_Id, x.LivresBook_Id });
                    table.ForeignKey(
                        name: "FK_Fluent_AuthorFluent_Book_Fluent_AuteursDeLivres_AuthorsA_Id",
                        column: x => x.AuthorsA_Id,
                        principalTable: "Fluent_AuteursDeLivres",
                        principalColumn: "A_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluent_AuthorFluent_Book_Fluent_Books_LivresBook_Id",
                        column: x => x.LivresBook_Id,
                        principalTable: "Fluent_Books",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_AuthorFluent_Book_LivresBook_Id",
                table: "Fluent_AuthorFluent_Book",
                column: "LivresBook_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fluent_AuthorFluent_Book");

            migrationBuilder.DropTable(
                name: "Fluent_AuteursDeLivres");
        }
    }
}
