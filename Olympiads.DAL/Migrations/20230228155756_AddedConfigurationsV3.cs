using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Olympiads.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedConfigurationsV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Students_StudentId",
                table: "StudentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Teachers_TeacherId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TeacherId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_StudentId",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentAnswers");

            migrationBuilder.AddColumn<string>(
                name: "TeacherEmail",
                table: "Teams",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentEmail",
                table: "StudentAnswers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeacherEmail",
                table: "Teams",
                column: "TeacherEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_StudentEmail",
                table: "StudentAnswers",
                column: "StudentEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Students_StudentEmail",
                table: "StudentAnswers",
                column: "StudentEmail",
                principalTable: "Students",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Teachers_TeacherEmail",
                table: "Teams",
                column: "TeacherEmail",
                principalTable: "Teachers",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Students_StudentEmail",
                table: "StudentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Teachers_TeacherEmail",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_TeacherEmail",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_StudentEmail",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "TeacherEmail",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "StudentEmail",
                table: "StudentAnswers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Teams",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Teams",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Teachers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentAnswers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeacherId",
                table: "Teams",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_StudentId",
                table: "StudentAnswers",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Students_StudentId",
                table: "StudentAnswers",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Teachers_TeacherId",
                table: "Teams",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
