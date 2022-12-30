using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class admneislemleri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Studyo_StudyoId",
                table: "Anime");

            migrationBuilder.DropForeignKey(
                name: "FK_Bolum_Anime_AnimeId",
                table: "Bolum");

            migrationBuilder.DropTable(
                name: "AnimeKategori");

            migrationBuilder.DropTable(
                name: "OnemliKarakterler");

            migrationBuilder.DropColumn(
                name: "YakindaCikicakMi",
                table: "Anime");

            migrationBuilder.RenameColumn(
                name: "yayinlanmaTarihi",
                table: "Bolum",
                newName: "YayinlanmaTarihi");

            migrationBuilder.AlterColumn<int>(
                name: "AnimeId",
                table: "Bolum",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StudyoId",
                table: "Anime",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CikisTarihi",
                table: "Anime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Fiyat",
                table: "Anime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Anime",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sepet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(nullable: true),
                    Fiyat = table.Column<double>(nullable: false),
                    Indirim = table.Column<double>(nullable: false),
                    SiparisOk = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sepet_Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(nullable: true),
                    SatinAlimTarihi = table.Column<DateTime>(nullable: false),
                    OdenenUcret = table.Column<double>(nullable: false),
                    SiparisKodu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siparis_Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anime_KategoriId",
                table: "Anime",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Sepet_AnimeId",
                table: "Sepet",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_AnimeId",
                table: "Siparis",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Studyo_KategoriId",
                table: "Anime",
                column: "KategoriId",
                principalTable: "Studyo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Studyo_StudyoId",
                table: "Anime",
                column: "StudyoId",
                principalTable: "Studyo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bolum_Anime_AnimeId",
                table: "Bolum",
                column: "AnimeId",
                principalTable: "Anime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Studyo_KategoriId",
                table: "Anime");

            migrationBuilder.DropForeignKey(
                name: "FK_Anime_Studyo_StudyoId",
                table: "Anime");

            migrationBuilder.DropForeignKey(
                name: "FK_Bolum_Anime_AnimeId",
                table: "Bolum");

            migrationBuilder.DropTable(
                name: "Sepet");

            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropIndex(
                name: "IX_Anime_KategoriId",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "CikisTarihi",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "Fiyat",
                table: "Anime");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Anime");

            migrationBuilder.RenameColumn(
                name: "YayinlanmaTarihi",
                table: "Bolum",
                newName: "yayinlanmaTarihi");

            migrationBuilder.AlterColumn<int>(
                name: "AnimeId",
                table: "Bolum",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudyoId",
                table: "Anime",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "YakindaCikicakMi",
                table: "Anime",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnimeKategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(type: "int", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeKategori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeKategori_Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeKategori_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnemliKarakterler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(type: "int", nullable: false),
                    KarakterinAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnemliKarakterler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnemliKarakterler_Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_OnemliKarakterler_AnimeId",
                table: "OnemliKarakterler",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_Studyo_StudyoId",
                table: "Anime",
                column: "StudyoId",
                principalTable: "Studyo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bolum_Anime_AnimeId",
                table: "Bolum",
                column: "AnimeId",
                principalTable: "Anime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
