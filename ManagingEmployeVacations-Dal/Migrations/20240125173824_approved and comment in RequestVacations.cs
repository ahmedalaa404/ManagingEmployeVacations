using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagingEmployeVacations_Dal.Migrations
{
    public partial class approvedandcommentinRequestVacations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "RequestsVacation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "RequestsVacation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateApproved",
                table: "RequestsVacation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "RequestsVacation");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "RequestsVacation");

            migrationBuilder.DropColumn(
                name: "DateApproved",
                table: "RequestsVacation");
        }
    }
}
