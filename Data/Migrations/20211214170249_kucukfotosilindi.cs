using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class kucukfotosilindi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_AnimeKucukFoto_AnimeKucukFotoId",
                table: "Anime");

            migrationBuilder.DropTable(
                name: "AnimeKucukFoto");

            migrationBuilder.DropIndex(
                name: "IX_Anime_AnimeKucukFotoId",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "AnimeKucukFotoId",
                table: "Anime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimeKucukFotoId",
                table: "Anime",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnimeKucukFoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(type: "int", nullable: true),
                    animeninKucukFotosu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeKucukFoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeKucukFoto_Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anime_AnimeKucukFotoId",
                table: "Anime",
                column: "AnimeKucukFotoId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeKucukFoto_AnimeId",
                table: "AnimeKucukFoto",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_AnimeKucukFoto_AnimeKucukFotoId",
                table: "Anime",
                column: "AnimeKucukFotoId",
                principalTable: "AnimeKucukFoto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
