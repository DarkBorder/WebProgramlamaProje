using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class sepethesapduzelttim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HesapId",
                table: "Sepet",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KutuphaneId",
                table: "Hesap",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SepetId",
                table: "Hesap",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sepet_HesapId",
                table: "Sepet",
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
                name: "FK_Hesap_Hesap_KutuphaneId",
                table: "Hesap",
                column: "KutuphaneId",
                principalTable: "Hesap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hesap_Hesap_SepetId",
                table: "Hesap",
                column: "SepetId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hesap_Hesap_KutuphaneId",
                table: "Hesap");

            migrationBuilder.DropForeignKey(
                name: "FK_Hesap_Hesap_SepetId",
                table: "Hesap");

            migrationBuilder.DropForeignKey(
                name: "FK_Sepet_Hesap_HesapId",
                table: "Sepet");

            migrationBuilder.DropIndex(
                name: "IX_Sepet_HesapId",
                table: "Sepet");

            migrationBuilder.DropIndex(
                name: "IX_Hesap_KutuphaneId",
                table: "Hesap");

            migrationBuilder.DropIndex(
                name: "IX_Hesap_SepetId",
                table: "Hesap");

            migrationBuilder.DropColumn(
                name: "HesapId",
                table: "Sepet");

            migrationBuilder.DropColumn(
                name: "KutuphaneId",
                table: "Hesap");

            migrationBuilder.DropColumn(
                name: "SepetId",
                table: "Hesap");
        }
    }
}
