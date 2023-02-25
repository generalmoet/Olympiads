using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Olympiads.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAnswerModelv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResponses_Question_QuestionId",
                table: "QuestionResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswer_Students_StudentId",
                table: "StudentAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAnswer",
                table: "StudentAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionResponses",
                table: "QuestionResponses");

            migrationBuilder.RenameTable(
                name: "StudentAnswer",
                newName: "StudentAnswers");

            migrationBuilder.RenameTable(
                name: "QuestionResponses",
                newName: "QuestionAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAnswer_StudentId",
                table: "StudentAnswers",
                newName: "IX_StudentAnswers_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionResponses_QuestionId",
                table: "QuestionAnswers",
                newName: "IX_QuestionAnswers_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAnswers",
                table: "StudentAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAnswers",
                table: "QuestionAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_Question_QuestionId",
                table: "QuestionAnswers",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Students_StudentId",
                table: "StudentAnswers",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_Question_QuestionId",
                table: "QuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Students_StudentId",
                table: "StudentAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAnswers",
                table: "StudentAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswers",
                table: "QuestionAnswers");

            migrationBuilder.RenameTable(
                name: "StudentAnswers",
                newName: "StudentAnswer");

            migrationBuilder.RenameTable(
                name: "QuestionAnswers",
                newName: "QuestionResponses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAnswers_StudentId",
                table: "StudentAnswer",
                newName: "IX_StudentAnswer_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAnswers_QuestionId",
                table: "QuestionResponses",
                newName: "IX_QuestionResponses_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAnswer",
                table: "StudentAnswer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionResponses",
                table: "QuestionResponses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResponses_Question_QuestionId",
                table: "QuestionResponses",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswer_Students_StudentId",
                table: "StudentAnswer",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
