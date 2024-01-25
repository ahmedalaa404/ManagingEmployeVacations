using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagingEmployeVacations_Dal.Migrations
{
    public partial class ChangeColumnInRequestVacation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestsVacation_Employees_EmpoyeeId",
                table: "RequestsVacation");

            migrationBuilder.RenameColumn(
                name: "EmpoyeeId",
                table: "RequestsVacation",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestsVacation_EmpoyeeId",
                table: "RequestsVacation",
                newName: "IX_RequestsVacation_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestsVacation_Employees_EmployeeId",
                table: "RequestsVacation",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestsVacation_Employees_EmployeeId",
                table: "RequestsVacation");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "RequestsVacation",
                newName: "EmpoyeeId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestsVacation_EmployeeId",
                table: "RequestsVacation",
                newName: "IX_RequestsVacation_EmpoyeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestsVacation_Employees_EmpoyeeId",
                table: "RequestsVacation",
                column: "EmpoyeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
