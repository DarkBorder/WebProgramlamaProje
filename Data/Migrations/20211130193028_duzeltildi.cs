using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class duzeltildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimeKategori",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(nullable: true),
                    KategoriId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeKategori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeKategori_Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimeKategori_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnemliKarakterler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KarakterinAdi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnemliKarakterler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studyo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyoAdi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studyo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeOnemliKarakterler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(nullable: true),
                    OnemliKarakterlerId = table.Column<int>(nullable: true),
                    OnemSirasi = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeOnemliKarakterler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeOnemliKarakterler_Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimeOnemliKarakterler_OnemliKarakterler_OnemliKarakterlerId",
                        column: x => x.OnemliKarakterlerId,
                        principalTable: "OnemliKarakterler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimeStudyo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(nullable: true),
                    StudyoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeStudyo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeStudyo_Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimeStudyo_Studyo_StudyoId",
                        column: x => x.StudyoId,
                        principalTable: "Studyo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeKategori_AnimeId",
                table: "AnimeKategori",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeKategori_KategoriId",
                table: "AnimeKategori",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeOnemliKarakterler_AnimeId",
                table: "AnimeOnemliKarakterler",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeOnemliKarakterler_OnemliKarakterlerId",
                table: "AnimeOnemliKarakterler",
                column: "OnemliKarakterlerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeStudyo_AnimeId",
                table: "AnimeStudyo",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeStudyo_StudyoId",
                table: "AnimeStudyo",
                column: "StudyoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeKategori");

            migrationBuilder.DropTable(
                name: "AnimeOnemliKarakterler");

            migrationBuilder.DropTable(
                name: "AnimeStudyo");

            migrationBuilder.DropTable(
                name: "OnemliKarakterler");

            migrationBuilder.DropTable(
                name: "Studyo");
        }
    }
}
