using Microsoft.EntityFrameworkCore.Migrations;

namespace WizLib_DataAccess.Migrations
{
    public partial class Ajout_Tables_Personne_et_Sexe_et_de_leur_Config_respective : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Sexes",
                columns: table => new
                {
                    Sexe_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Sexes", x => x.Sexe_Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Personnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheSexeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Personnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Personnes_tb_Sexes_TheSexeId",
                        column: x => x.TheSexeId,
                        principalTable: "tb_Sexes",
                        principalColumn: "Sexe_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Personnes_TheSexeId",
                table: "tb_Personnes",
                column: "TheSexeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Personnes");

            migrationBuilder.DropTable(
                name: "tb_Sexes");
        }
    }
}
