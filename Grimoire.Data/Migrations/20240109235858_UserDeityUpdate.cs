using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grimoire.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserDeityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<int>(
                name: "DeityId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeityId",
                table: "Users",
                column: "DeityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Deities_DeityId",
                table: "Users",
                column: "DeityId",
                principalTable: "Deities",
                principalColumn: "DeityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Deities_DeityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DeityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeityId",
                table: "Users");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Users",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
