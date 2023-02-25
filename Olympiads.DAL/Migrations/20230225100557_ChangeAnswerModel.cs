using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Olympiads.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAnswerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResponses_Students_StudentId",
                table: "QuestionResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Teams_TeamId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionResponses_StudentId",
                table: "QuestionResponses");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "QuestionResponses");

            migrationBuilder.RenameColumn(
                name: "Right",
                table: "QuestionResponses",
                newName: "RightAnswer");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Teachers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "TeamId1",
                table: "Teachers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAnswer_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeamId1",
                table: "Teachers",
                column: "TeamId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswer_StudentId",
                table: "StudentAnswer",
                column: "StudentId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Teams_TeamId",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Teams_TeamId1",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "StudentAnswer");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeamId1",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeamId1",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "RightAnswer",
                table: "QuestionResponses",
                newName: "Right");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Teachers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "QuestionResponses",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponses_StudentId",
                table: "QuestionResponses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResponses_Students_StudentId",
                table: "QuestionResponses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Teams_TeamId",
                table: "Teachers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
