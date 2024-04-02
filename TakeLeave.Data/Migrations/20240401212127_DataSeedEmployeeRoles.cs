using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeLeave.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedEmployeeRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT EmployeeRoles ON " +
                "IF NOT EXISTS (SELECT 1 FROM EmployeeRoles WHERE Name = 'Admin') " +
                "INSERT INTO EmployeeRoles " +
                "(Id, Name, NormalizedName, ConcurrencyStamp) " +
                "VALUES " +
                "(1, 'Admin', 'ADMIN', NULL)");

            migrationBuilder.Sql("SET IDENTITY_INSERT EmployeeRoles ON " +
                "IF NOT EXISTS (SELECT 1 FROM EmployeeRoles WHERE Name = 'User') " +
                "INSERT INTO EmployeeRoles " +
                "(Id, Name, NormalizedName, ConcurrencyStamp) " +
                "VALUES " +
                "(2, 'User', 'USER', NULL)");

            migrationBuilder.Sql("SET IDENTITY_INSERT EmployeeRoles ON " +
                "IF NOT EXISTS (SELECT 1 FROM EmployeeRoles WHERE Name = 'HR') " +
                "INSERT INTO EmployeeRoles " +
                "(Id, Name, NormalizedName, ConcurrencyStamp) " +
                "VALUES " +
                "(3, 'HR', 'HR', NULL)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
