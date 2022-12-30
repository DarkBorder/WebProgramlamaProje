using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class bolumdoluluk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KacinciSezon",
                table: "Anime");

            migrationBuilder.AddColumn<int>(
                name: "KacBolumTamamlandi",
                table: "Anime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KacBolumTamamlandi",
                table: "Anime");

            migrationBuilder.AddColumn<int>(
                name: "KacinciSezon",
                table: "Anime",
                type: "int",
                nullable: true);
        }
    }
}
