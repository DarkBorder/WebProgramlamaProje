using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class kutuphaneDegisi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnimeAd",
                table: "Kutuphane",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnimeFoto",
                table: "Kutuphane",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimeAd",
                table: "Kutuphane");

            migrationBuilder.DropColumn(
                name: "AnimeFoto",
                table: "Kutuphane");
        }
    }
}
