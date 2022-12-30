using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class BolumEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeKategori_Anime_AnimeId",
                table: "AnimeKategori");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeKategori_Kategori_KategoriId",
                table: "AnimeKategori");

            migrationBuilder.DropTable(
                name: "AnimeOnemliKarakterler");

            migrationBuilder.DropTable(
                name: "AnimeStudyo");

            migrationBuilder.DropColumn(
                name: "Sezon",
                table: "Anime");

            migrationBuilder.AddColumn<int>(
                name: "AnimeId",
                table: "OnemliKarakterler",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "AnimeKategori",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimeId",
                table: "AnimeKategori",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AktifMi",
                table: "Anime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HangiSezondaCikti",
                table: "Anime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KacinciSezon",
                table: "Anime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudyoId",
                table: "Anime",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "YakindaCikicakMi",
                table: "Anime",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bolum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumAdi = table.Column<string>(nullable: true),
                    KacinciBolum = table.Column<int>(nullable: false),
                    yayinlanmaTarihi = table.Column<DateTime>(nullable: false),
                    AnimeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bolum_Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnemliKarakterler_AnimeId",
                table: "OnemliKarakterler",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_StudyoId",
                table: "Anime",
                column: "StudyoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bolum_AnimeId",
                table: "Bolum",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Studyo_StudyoId",
                table: "Anime",
                column: "StudyoId",
                principalTable: "Studyo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeKategori_Anime_AnimeId",
                table: "AnimeKategori",
                column: "AnimeId",
                principalTable: "Anime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeKategori_Kategori_KategoriId",
                table: "AnimeKategori",
                column: "KategoriId",
                principalTable: "Kategori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnemliKarakterler_Anime_AnimeId",
                table: "OnemliKarakterler",
                column: "AnimeId",
                principalTable: "Anime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Studyo_StudyoId",
                table: "Anime");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeKategori_Anime_AnimeId",
                table: "AnimeKategori");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeKategori_Kategori_KategoriId",
                table: "AnimeKategori");

            migrationBuilder.DropForeignKey(
                name: "FK_OnemliKarakterler_Anime_AnimeId",
                table: "OnemliKarakterler");

            migrationBuilder.DropTable(
                name: "Bolum");

            migrationBuilder.DropIndex(
                name: "IX_OnemliKarakterler_AnimeId",
                table: "OnemliKarakterler");

            migrationBuilder.DropIndex(
                name: "IX_Anime_StudyoId",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "AnimeId",
                table: "OnemliKarakterler");

            migrationBuilder.DropColumn(
                name: "AktifMi",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "HangiSezondaCikti",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "KacinciSezon",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "StudyoId",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "YakindaCikicakMi",
                table: "Anime");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "AnimeKategori",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AnimeId",
                table: "AnimeKategori",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Sezon",
                table: "Anime",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnimeOnemliKarakterler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(type: "int", nullable: true),
                    OnemSirasi = table.Column<int>(type: "int", nullable: true),
                    OnemliKarakterlerId = table.Column<int>(type: "int", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(type: "int", nullable: true),
                    StudyoId = table.Column<int>(type: "int", nullable: true)
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
    }
}
