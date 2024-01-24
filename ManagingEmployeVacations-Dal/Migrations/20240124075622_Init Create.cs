using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagingEmployeVacations_Dal.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VacationBalance = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestsVacation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpoyeeId = table.Column<int>(type: "int", nullable: false),
                    DateRequestVacation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDateVacations = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateVacations = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VacationTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestsVacation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestsVacation_Employees_EmpoyeeId",
                        column: x => x.EmpoyeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestsVacation_VacationsType_VacationTypeId",
                        column: x => x.VacationTypeId,
                        principalTable: "VacationsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacationsDatePlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacationRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationsDatePlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationsDatePlan_RequestsVacation_VacationRequestId",
                        column: x => x.VacationRequestId,
                        principalTable: "RequestsVacation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsVacation_EmpoyeeId",
                table: "RequestsVacation",
                column: "EmpoyeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestsVacation_VacationTypeId",
                table: "RequestsVacation",
                column: "VacationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationsDatePlan_VacationRequestId",
                table: "VacationsDatePlan",
                column: "VacationRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacationsDatePlan");

            migrationBuilder.DropTable(
                name: "RequestsVacation");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "VacationsType");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
