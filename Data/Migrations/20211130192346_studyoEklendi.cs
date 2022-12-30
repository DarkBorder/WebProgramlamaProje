using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class studyoEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Dil_DilId",
                table: "Anime");

            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Kategori_KategoriId",
                table: "Anime");

            migrationBuilder.DropTable(
                name: "Dil");

            migrationBuilder.DropIndex(
                name: "IX_Anime_DilId",
                table: "Anime");

            migrationBuilder.DropIndex(
                name: "IX_Anime_KategoriId",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "DilId",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "Studyo",
                table: "Anime");

            migrationBuilder.AddColumn<int>(
                name: "Sezon",
                table: "Anime",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sezon",
                table: "Anime");

            migrationBuilder.AddColumn<int>(
                name: "DilId",
                table: "Anime",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Anime",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Studyo",
                table: "Anime",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DilAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dil", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anime_DilId",
                table: "Anime",
                column: "DilId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_KategoriId",
                table: "Anime",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Dil_DilId",
                table: "Anime",
                column: "DilId",
                principalTable: "Dil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Kategori_KategoriId",
                table: "Anime",
                column: "KategoriId",
                principalTable: "Kategori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
