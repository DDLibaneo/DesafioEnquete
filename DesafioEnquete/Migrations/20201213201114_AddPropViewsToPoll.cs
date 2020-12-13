using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioEnquete.Migrations
{
    public partial class AddPropViewsToPoll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Polls",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "Polls");
        }
    }
}
