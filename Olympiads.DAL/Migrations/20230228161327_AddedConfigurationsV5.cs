using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Olympiads.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedConfigurationsV5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Students_StudentEmail",
                table: "StudentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Teams_TeamName",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Teachers_TeacherEmail",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
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
                name: "IX_Students_Email",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_TeamName",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_StudentEmail",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "TeacherEmail",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamName",
                table: "Students");

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
                name: "TeamId",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StudentAnswers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Name",
                table: "Teams",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeamId",
                table: "Students",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Students_Id",
                table: "StudentAnswers",
                column: "Id",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Teams_TeamId",
                table: "Students",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Teachers_Id",
                table: "Teams",
                column: "Id",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Students_Id",
                table: "StudentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Teams_TeamId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Teachers_Id",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_Name",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_TeamId",
                table: "Students");

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
                name: "TeamId",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "TeacherEmail",
                table: "Teams",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeamName",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StudentAnswers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Name");

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
                name: "IX_Students_Email",
                table: "Students",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeamName",
                table: "Students",
                column: "TeamName");

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
                name: "FK_Students_Teams_TeamName",
                table: "Students",
                column: "TeamName",
                principalTable: "Teams",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Teachers_TeacherEmail",
                table: "Teams",
                column: "TeacherEmail",
                principalTable: "Teachers",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
