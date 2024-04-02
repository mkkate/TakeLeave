using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeLeave.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedingEmployee2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT DaysOffs ON " +
                "IF NOT EXISTS (SELECT 1 FROM DaysOffs WHERE ID = 2) " +
                "INSERT INTO DaysOffs " +
                "(ID, Vacation, Paid, Unpaid, SickLeave) " +
                "VALUES " +
                $"(2, {20}, {5}, {0}, {11})");

            migrationBuilder.Sql("IF NOT EXISTS (SELECT 1 FROM Employees WHERE UserName = 'emma.scott') " +
                "INSERT INTO Employees " +
                "(FirstName, LastName, Address, IDNumber, EmploymentStartDate, EmploymentEndDate, InsertDate, DeleteDate, DaysOffID," +
                " PositionID, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp," +
                " PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, IsAdmin) " +
                "VALUES " +
                $"('Emma','Scott','Boulevard Sur Salazar 4098','165547308',GETUTCDATE(),GETUTCDATE(),GETUTCDATE(),NULL,{2},{2},'emma.scott','EMMA.SCOTT'," +
                $"'emma.scott@gmail.com','EMMA.SCOTT@GMAIL.COM',1,'AQAAAAIAAYagAAAAEJ3LslypDuJfd9xso65trCKXqShi1dn6gi9pv/oP+rZi+8gza9Pos6P4ZavxbrjEIQ=='," +
                $"'{Guid.NewGuid()}','{Guid.NewGuid()}','0600065100',1,0,NULL,1,0,1)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
