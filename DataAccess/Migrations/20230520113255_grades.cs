    using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class grades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AEPassed",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "BDPassed",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SCPassed",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TBPassed",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TUPassed",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "cppPassed",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "lastScoreAE",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "lastScoreBD",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "lastScoreCpp",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "lastScorePseudocod",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "lastScoreRec",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "lastScoreSC",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "lastScoreTB",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "lastScoreTU",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "maxScoreAE",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "maxScoreBD",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "maxScoreCpp",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "maxScorePseudocod",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "maxScoreRec",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "maxScoreSC",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "maxScoreTB",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "maxScoreTU",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "pseudocodPassed",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "recPassed",
                table: "Users",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AEPassed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BDPassed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SCPassed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TBPassed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TUPassed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "cppPassed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastScoreAE",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastScoreBD",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastScoreCpp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastScorePseudocod",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastScoreRec",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastScoreSC",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastScoreTB",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "lastScoreTU",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "maxScoreAE",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "maxScoreBD",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "maxScoreCpp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "maxScorePseudocod",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "maxScoreRec",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "maxScoreSC",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "maxScoreTB",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "maxScoreTU",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "pseudocodPassed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "recPassed",
                table: "Users");
        }
    }
}
