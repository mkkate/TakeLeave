using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeLeave.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedingPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("SET IDENTITY_INSERT Positions ON " +
                "INSERT INTO Positions " +
                "(ID, Title, Description, SeniorityLevel) " +
                "VALUES " +
                "(1, 'HR Manager', 'Oversees all HR tasks, including recruiting, training, payroll, benefits and employee relations', 2)");

            migrationBuilder.Sql("SET IDENTITY_INSERT Positions ON " +
                "INSERT INTO Positions " +
                "(ID, Title, Description, SeniorityLevel) " +
                "VALUES " +
                "(2, 'Software Developer','Designing software for businesses and consumers alike, working closely with clients to determine what they need', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
