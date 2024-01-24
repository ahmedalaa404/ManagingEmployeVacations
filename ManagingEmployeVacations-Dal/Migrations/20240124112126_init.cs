using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagingEmployeVacations_Dal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Background_Color",
                table: "VacationsType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Background_Color",
                table: "VacationsType");
        }
    }
}
