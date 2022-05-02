using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _5I_Frisoni_Differenze.Migrations
{
    public partial class CreazioneDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DomandeImmagine",
                columns: table => new
                {
                    DomandaImmagineID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PercorsoOriginale = table.Column<string>(type: "TEXT", nullable: true),
                    PercorsoModificata = table.Column<string>(type: "TEXT", nullable: true),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomandeImmagine", x => x.DomandaImmagineID);
                });

            migrationBuilder.CreateTable(
                name: "Differenze",
                columns: table => new
                {
                    idDifferenza = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    X = table.Column<int>(type: "INTEGER", nullable: false),
                    Y = table.Column<int>(type: "INTEGER", nullable: false),
                    Raggio = table.Column<int>(type: "INTEGER", nullable: false),
                    DomandaImmagineID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Differenze", x => x.idDifferenza);
                    table.ForeignKey(
                        name: "FK_Differenze_DomandeImmagine_DomandaImmagineID",
                        column: x => x.DomandaImmagineID,
                        principalTable: "DomandeImmagine",
                        principalColumn: "DomandaImmagineID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Differenze_DomandaImmagineID",
                table: "Differenze",
                column: "DomandaImmagineID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Differenze");

            migrationBuilder.DropTable(
                name: "DomandeImmagine");
        }
    }
}
