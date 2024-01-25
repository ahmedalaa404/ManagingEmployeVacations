using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagingEmployeVacations_Dal.Migrations
{
    public partial class AddColumninVacationPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "VacationDate",
                table: "VacationsDatePlan",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VacationDate",
                table: "VacationsDatePlan");
        }
    }
}
