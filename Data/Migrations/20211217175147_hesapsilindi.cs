using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class hesapsilindi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kutuphane_Hesap_HesapId",
                table: "Kutuphane");

            migrationBuilder.DropForeignKey(
                name: "FK_Sepet_Hesap_HesapId",
                table: "Sepet");

            migrationBuilder.DropTable(
                name: "Hesap");

            migrationBuilder.DropIndex(
                name: "IX_Sepet_HesapId",
                table: "Sepet");

            migrationBuilder.DropIndex(
                name: "IX_Kutuphane_HesapId",
                table: "Kutuphane");

            migrationBuilder.DropColumn(
                name: "HesapId",
                table: "Sepet");

            migrationBuilder.DropColumn(
                name: "HesapId",
                table: "Kutuphane");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HesapId",
                table: "Sepet",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HesapId",
                table: "Kutuphane",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hesap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KutuphaneId = table.Column<int>(type: "int", nullable: true),
                    SepetId = table.Column<int>(type: "int", nullable: true),
                    SoyAd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hesap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hesap_Hesap_KutuphaneId",
                        column: x => x.KutuphaneId,
                        principalTable: "Hesap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hesap_Hesap_SepetId",
                        column: x => x.SepetId,
                        principalTable: "Hesap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sepet_HesapId",
                table: "Sepet",
                column: "HesapId");

            migrationBuilder.CreateIndex(
                name: "IX_Kutuphane_HesapId",
                table: "Kutuphane",
                column: "HesapId");

            migrationBuilder.CreateIndex(
                name: "IX_Hesap_KutuphaneId",
                table: "Hesap",
                column: "KutuphaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Hesap_SepetId",
                table: "Hesap",
                column: "SepetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kutuphane_Hesap_HesapId",
                table: "Kutuphane",
                column: "HesapId",
                principalTable: "Hesap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sepet_Hesap_HesapId",
                table: "Sepet",
                column: "HesapId",
                principalTable: "Hesap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
