using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grimoire.Data.Migrations
{
    /// <inheritdoc />
    public partial class DeityEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Deities");

            migrationBuilder.AddColumn<string>(
                name: "Power",
                table: "Deities",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Power",
                table: "Deities");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Deities",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }
    }
}
