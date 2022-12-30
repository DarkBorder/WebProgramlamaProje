using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class sezonoeklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartNo",
                table: "Anime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SezonNo",
                table: "Anime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartNo",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "SezonNo",
                table: "Anime");
        }
    }
}
