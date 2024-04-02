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
                "IF NOT EXISTS (SELECT 1 FROM Positions WHERE ID = 1) " +
                "INSERT INTO Positions " +
                "(ID, Title, Description, SeniorityLevel) " +
                "VALUES " +
                "(1, 'HR Manager', 'Oversees all HR tasks, including recruiting, training, payroll, benefits and employee relations', 2)");

            migrationBuilder.Sql("SET IDENTITY_INSERT Positions ON " +
                "IF NOT EXISTS (SELECT 1 FROM Positions WHERE ID = 2) " +
                "INSERT INTO Positions " +
                "(ID, Title, Description, SeniorityLevel) " +
                "VALUES " +
                "(2, 'Software Developer','Designing software for businesses and consumers alike, working closely with clients to determine what they need', 1)");

            migrationBuilder.Sql("SET IDENTITY_INSERT Positions ON " +
                "IF NOT EXISTS (SELECT 1 FROM Positions WHERE ID = 3) " +
                "INSERT INTO Positions " +
                "(ID, Title, Description, SeniorityLevel) " +
                "VALUES " +
                "(3, 'Recruiter','Creates recruiting plans and search for new talent through a network of industry organizations, professional contacts, social media, job fairs and more', 1)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
