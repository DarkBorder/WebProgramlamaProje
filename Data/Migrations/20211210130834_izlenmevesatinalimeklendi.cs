using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class izlenmevesatinalimeklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IzlenmeSayisi",
                table: "Anime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SatinAlimSayisi",
                table: "Anime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IzlenmeSayisi",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "SatinAlimSayisi",
                table: "Anime");
        }
    }
}
