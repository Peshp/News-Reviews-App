using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News_Reviews.Data.Migrations
{
    public partial class ChangeConfigurator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Title",
                value: "Mostly action, I guess.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Title",
                value: "I like logic, such as simple puzzles.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Title",
                value: "A good balance of both");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Title",
                value: "A good balance of both");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Title",
                value: "Mostly action, I guess.");

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Title",
                value: "I like logic, such as simple puzzles.");
        }
    }
}
