using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class ManyToMany_Relation_Between_Authors_And_Books : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    ParticipatedBooksBook_Id = table.Column<int>(type: "int", nullable: false),
                    ParticipatingAuthorsAuthor_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.ParticipatedBooksBook_Id, x.ParticipatingAuthorsAuthor_Id });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_ParticipatingAuthorsAuthor_Id",
                        column: x => x.ParticipatingAuthorsAuthor_Id,
                        principalTable: "Authors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_ParticipatedBooksBook_Id",
                        column: x => x.ParticipatedBooksBook_Id,
                        principalTable: "Books",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_ParticipatingAuthorsAuthor_Id",
                table: "AuthorBook",
                column: "ParticipatingAuthorsAuthor_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");
        }
    }
}
