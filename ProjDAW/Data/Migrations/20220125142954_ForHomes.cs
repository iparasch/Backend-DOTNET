using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjDAW.Data.Migrations
{
    public partial class ForHomes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Home",
                table: "Home");

            migrationBuilder.RenameTable(
                name: "Home",
                newName: "ForHomes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForHomes",
                table: "ForHomes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ForHomes",
                table: "ForHomes");

            migrationBuilder.RenameTable(
                name: "ForHomes",
                newName: "Home");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Home",
                table: "Home",
                column: "Id");
        }
    }
}
