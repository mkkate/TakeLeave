using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeLeave.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeenPropertyAddedToChatMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "ChatMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seen",
                table: "ChatMessages");
        }
    }
}
