using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grimoire.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Deities_DeityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DeityId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "DeityEntityUserEntity",
                columns: table => new
                {
                    DeitiesDeityId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeityEntityUserEntity", x => new { x.DeitiesDeityId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_DeityEntityUserEntity_Deities_DeitiesDeityId",
                        column: x => x.DeitiesDeityId,
                        principalTable: "Deities",
                        principalColumn: "DeityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeityEntityUserEntity_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeityEntityUserEntity_UsersId",
                table: "DeityEntityUserEntity",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeityEntityUserEntity");

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
    }
}
