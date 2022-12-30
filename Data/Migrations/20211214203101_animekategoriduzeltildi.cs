using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class animekategoriduzeltildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeKategori_Studyo_AnimeId",
                table: "AnimeKategori");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeKategori_Studyo_KategoriId",
                table: "AnimeKategori");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeKategori_Anime_AnimeId",
                table: "AnimeKategori",
                column: "AnimeId",
                principalTable: "Anime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeKategori_Kategori_KategoriId",
                table: "AnimeKategori",
                column: "KategoriId",
                principalTable: "Kategori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeKategori_Anime_AnimeId",
                table: "AnimeKategori");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeKategori_Kategori_KategoriId",
                table: "AnimeKategori");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeKategori_Studyo_AnimeId",
                table: "AnimeKategori",
                column: "AnimeId",
                principalTable: "Studyo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeKategori_Studyo_KategoriId",
                table: "AnimeKategori",
                column: "KategoriId",
                principalTable: "Studyo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
