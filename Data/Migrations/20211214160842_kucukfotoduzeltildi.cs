using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class kucukfotoduzeltildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimeKucukFotoId",
                table: "Anime",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Anime_AnimeKucukFotoId",
                table: "Anime",
                column: "AnimeKucukFotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_AnimeKucukFoto_AnimeKucukFotoId",
                table: "Anime",
                column: "AnimeKucukFotoId",
                principalTable: "AnimeKucukFoto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_AnimeKucukFoto_AnimeKucukFotoId",
                table: "Anime");

            migrationBuilder.DropIndex(
                name: "IX_Anime_AnimeKucukFotoId",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "AnimeKucukFotoId",
                table: "Anime");
        }
    }
}
