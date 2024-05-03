#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeLeave.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeRoleIdToPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeRoleID",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_EmployeeRoleID",
                table: "Positions",
                column: "EmployeeRoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_EmployeeRoles_EmployeeRoleID",
                table: "Positions",
                column: "EmployeeRoleID",
                principalTable: "EmployeeRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_EmployeeRoles_EmployeeRoleID",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_EmployeeRoleID",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "EmployeeRoleID",
                table: "Positions");
        }
    }
}
