using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquariumForum.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToDiscussion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Discussion",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Discussion_UserId",
                table: "Discussion",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discussion_AspNetUsers_UserId",
                table: "Discussion",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discussion_AspNetUsers_UserId",
                table: "Discussion");

            migrationBuilder.DropIndex(
                name: "IX_Discussion_UserId",
                table: "Discussion");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Discussion");
        }
    }
}
