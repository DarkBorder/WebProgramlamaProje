using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class hesapeklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropColumn(
                name: "YayinlanmaTarihi",
                table: "Bolum");

            migrationBuilder.CreateTable(
                name: "Hesap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    SoyAd = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    KayitTarihi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hesap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kutuphane",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HesapId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kutuphane", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kutuphane_Hesap_HesapId",
                        column: x => x.HesapId,
                        principalTable: "Hesap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kutuphane_HesapId",
                table: "Kutuphane",
                column: "HesapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kutuphane");

            migrationBuilder.DropTable(
                name: "Hesap");

            migrationBuilder.AddColumn<DateTime>(
                name: "YayinlanmaTarihi",
                table: "Bolum",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(type: "int", nullable: true),
                    OdenenUcret = table.Column<double>(type: "float", nullable: true),
                    SatinAlimTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SiparisKodu = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "IX_Siparis_AnimeId",
                table: "Siparis",
                column: "AnimeId");
        }
    }
}
