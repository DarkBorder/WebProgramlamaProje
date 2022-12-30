using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class pkdegisti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sepet",
                table: "Sepet");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sepet");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Sepet",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sepet",
                table: "Sepet",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sepet",
                table: "Sepet");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Sepet");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Sepet",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sepet",
                table: "Sepet",
                column: "Id");
        }
    }
}
