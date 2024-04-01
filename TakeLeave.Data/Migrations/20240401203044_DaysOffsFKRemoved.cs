using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeLeave.Data.Migrations
{
    /// <inheritdoc />
    public partial class DaysOffsFKRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "DaysOffs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "DaysOffs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
