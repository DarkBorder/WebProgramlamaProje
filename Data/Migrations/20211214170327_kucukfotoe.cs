using Microsoft.EntityFrameworkCore.Migrations;


namespace AnimeBox.Data.Migrations
{
    public partial class kucukfotoe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnimeKucukFoto",
                table: "Anime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimeKucukFoto",
                table: "Anime");
        }
    }
}
