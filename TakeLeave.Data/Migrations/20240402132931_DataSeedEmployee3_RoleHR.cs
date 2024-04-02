using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeLeave.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedEmployee3_RoleHR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT DaysOffs ON " +
                "IF NOT EXISTS (SELECT 1 FROM DaysOffs WHERE ID = 3) " +
               "INSERT INTO DaysOffs " +
               "(ID, Vacation, Paid, Unpaid, SickLeave) " +
               "VALUES " +
               $"(3, {21}, {5}, {0}, {11})");

            migrationBuilder.Sql("IF NOT EXISTS (SELECT 1 FROM Employees WHERE UserName = 'jack.davis') " +
                "INSERT INTO Employees " +
                "(FirstName, LastName, Address, IDNumber, EmploymentStartDate, EmploymentEndDate, InsertDate, DeleteDate, DaysOffID," +
                " PositionID, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp," +
                " PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, IsAdmin) " +
                "VALUES " +
                $"('Jack','Davis','Sheffield S10 5TU, UK','225547488',GETUTCDATE(),GETUTCDATE(),GETUTCDATE(),NULL,{3},{3},'jack.davis','JACK.DAVIS'," +
                $"'jack.davis@gmail.com','JACK.DAVIS@GMAIL.COM',1,'AQAAAAIAAYagAAAAEMHH3gp2fpbiVnrY905Jwx451ghETGYScHkp24DH7sjfxNj/O51bUgxS/2LfACTqyg=='," +
                $"'{Guid.NewGuid()}','{Guid.NewGuid()}','2634065100',1,0,NULL,1,0,0)");

            migrationBuilder.Sql("IF NOT EXISTS (SELECT 1 FROM EmployeeUserRoles WHERE UserId = 3 AND RoleId = 3) " +
                "INSERT INTO EmployeeUserRoles " +
                "(UserId, RoleId) " +
                "VALUES " +
                "(3, 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
