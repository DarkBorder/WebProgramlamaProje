using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeBox.Data.Migrations
{
    public partial class bencesepetbitti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sepet",
                table: "Sepet");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Sepet",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Sepet",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sepet",
                table: "Sepet",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sepet",
                table: "Sepet");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sepet");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Sepet",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sepet",
                table: "Sepet",
                column: "Email");
        }
    }
}
