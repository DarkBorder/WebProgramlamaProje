using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class yapimciEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Studyo_KategoriId",
                table: "Anime");

            migrationBuilder.DropIndex(
                name: "IX_Anime_KategoriId",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "BolumUzunlugu",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "CikisTarihi",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "YapimYili",
                table: "Anime");

            migrationBuilder.AddColumn<DateTime>(
                name: "BaslamaTarihi",
                table: "Anime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BitisTarihi",
                table: "Anime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "BolumSuresi",
                table: "Anime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YasSiniri",
                table: "Anime",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnimeKategori",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(nullable: true),
                    KategoriId = table.Column<int>(nullable: true),
                    OnemSirasi = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeKategori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeKategori_Studyo_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Studyo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimeKategori_Studyo_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Studyo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimeYapimci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(nullable: true),
                    YapimciId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeYapimci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeYapimci_Studyo_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Studyo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnimeYapimci_Studyo_YapimciId",
                        column: x => x.YapimciId,
                        principalTable: "Studyo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Yapimci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YapimciFirmaAdi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yapimci", x => x.Id);
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
                name: "IX_AnimeYapimci_AnimeId",
                table: "AnimeYapimci",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeYapimci_YapimciId",
                table: "AnimeYapimci",
                column: "YapimciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeKategori");

            migrationBuilder.DropTable(
                name: "AnimeYapimci");

            migrationBuilder.DropTable(
                name: "Yapimci");

            migrationBuilder.DropColumn(
                name: "BaslamaTarihi",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "BitisTarihi",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "BolumSuresi",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "YasSiniri",
                table: "Anime");

            migrationBuilder.AddColumn<double>(
                name: "BolumUzunlugu",
                table: "Anime",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CikisTarihi",
                table: "Anime",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Anime",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YapimYili",
                table: "Anime",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Anime_KategoriId",
                table: "Anime",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Studyo_KategoriId",
                table: "Anime",
                column: "KategoriId",
                principalTable: "Studyo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
