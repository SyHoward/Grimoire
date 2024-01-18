using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grimoire.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeityId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeityId",
                table: "Users",
                type: "int",
                nullable: true);
        }
    }
}
