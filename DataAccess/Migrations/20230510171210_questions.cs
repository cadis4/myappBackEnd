using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class questions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VerifyAnswer",
                table: "Questions",
                newName: "CorrectAnswer");

            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "Questions",
                newName: "AnswerTwo");

            migrationBuilder.AddColumn<string>(
                name: "AnswerFour",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnswerOne",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnswerThree",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerFour",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AnswerOne",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AnswerThree",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "CorrectAnswer",
                table: "Questions",
                newName: "VerifyAnswer");

            migrationBuilder.RenameColumn(
                name: "AnswerTwo",
                table: "Questions",
                newName: "Answer");
        }
    }
}
