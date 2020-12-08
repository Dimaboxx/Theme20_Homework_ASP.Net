using Microsoft.EntityFrameworkCore.Migrations;

namespace Theme_20_Homework_fromEmpty.Migrations
{
    public partial class bug1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "currentUserID",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "currentUserID",
                table: "Game");
        }
    }
}
