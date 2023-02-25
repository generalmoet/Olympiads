using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Olympiads.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAnswerModelv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Teams_TeamId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Teams_TeamId1",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeamId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeamId1",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeamId1",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Teams",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeacherId",
                table: "Teams",
                column: "TeacherId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Teachers_TeacherId",
                table: "Teams",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Teachers_TeacherId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TeacherId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Teachers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId1",
                table: "Teachers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeamId",
                table: "Teachers",
                column: "TeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeamId1",
                table: "Teachers",
                column: "TeamId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Teams_TeamId",
                table: "Teachers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Teams_TeamId1",
                table: "Teachers",
                column: "TeamId1",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
