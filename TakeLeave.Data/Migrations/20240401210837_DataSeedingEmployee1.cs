using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeLeave.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedingEmployee1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT DaysOffs ON " +
                "IF NOT EXISTS (SELECT 1 FROM DaysOffs WHERE ID = 1) " +
                "INSERT INTO DaysOffs " +
                "(ID, Vacation, Paid, Unpaid, SickLeave) " +
                "VALUES " +
                $"(1, {22}, {5}, {0}, {11})");

            migrationBuilder.Sql("IF NOT EXISTS (SELECT 1 FROM Employees WHERE UserName = 'maria.evans') " +
                "INSERT INTO Employees " +
                "(FirstName, LastName, Address, IDNumber, EmploymentStartDate, EmploymentEndDate, InsertDate, DeleteDate, DaysOffID," +
                " PositionID, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp," +
                " PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, IsAdmin) " +
                "VALUES " +
                $"('Maria','Evans','Boelhof 1723','16837308',GETUTCDATE(),GETUTCDATE(),GETUTCDATE(),NULL,{1},{1},'maria.evans','MARIA.EVANS'," +
                $"'maria.evans@gmail.com','MARIA.EVANS@GMAIL.COM',1,'AQAAAAIAAYagAAAAECuVyIumpN/a0/D5PAS3Ynila7mmRmPHRBoCu7BCns6RRI4+Ub9baxgtiYR3QL9vGw=='," +
                $"'{Guid.NewGuid()}','{Guid.NewGuid()}','0600000000',1,0,NULL,1,0,1)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
