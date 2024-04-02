using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeLeave.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedEmployeeUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF NOT EXISTS (SELECT 1 FROM EmployeeUserRoles WHERE UserId = 1 AND RoleId = 1) " +
                "INSERT INTO EmployeeUserRoles " +
                "(UserId, RoleId) " +
                "VALUES " +
                "(1, 1)");

            migrationBuilder.Sql("UPDATE Employees " +
                "SET IsAdmin = 0 " +
                "WHERE Id = 2 ");

            migrationBuilder.Sql("IF NOT EXISTS (SELECT 1 FROM EmployeeUserRoles WHERE UserId = 2 AND RoleId = 2) " +
                "INSERT INTO EmployeeUserRoles " +
                "(UserId, RoleId) " +
                "VALUES " +
                "(2, 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
