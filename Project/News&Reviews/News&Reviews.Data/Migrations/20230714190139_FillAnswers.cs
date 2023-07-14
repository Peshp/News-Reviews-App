using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News_Reviews.Data.Migrations
{
    public partial class FillAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Points", "QuestionId", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "More than a week" },
                    { 2, 2, 1, "Months and months" },
                    { 3, 3, 1, "Short campaign with an online multiplayer option to play for months" },
                    { 4, 4, 1, "Something short" },
                    { 5, 5, 1, "Not particularly bothered" },
                    { 6, 6, 1, "I want a game that takes up all my time but that I've finished within a few weeks." },
                    { 7, 1, 2, "Logic all the way. Games should be a strategic plan." },
                    { 8, 2, 2, "A good balance of both" },
                    { 9, 3, 2, "Mostly action, I guess." },
                    { 10, 4, 2, "I like logic, such as simple puzzles." },
                    { 11, 1, 3, "Strategy and logic" },
                    { 12, 2, 3, "Multiplayer options" },
                    { 13, 3, 3, "A vast array of guns and weapons " },
                    { 14, 4, 3, "Good puzzles and short, simple gameplay" },
                    { 15, 5, 3, "Lots of action, combat, and story" },
                    { 16, 6, 3, "Leveling up and ability to change features " },
                    { 17, 1, 4, "Nope! Not at all" },
                    { 18, 2, 4, "A little. It depends on my mood." },
                    { 19, 3, 4, "Sometimes" },
                    { 20, 4, 4, "Yes! Long and complicated games bore me. " },
                    { 21, 5, 4, "Yeah, a little. I need something to constantly require my attention." },
                    { 22, 1, 5, "I like a good choice of current songs playing in the background." },
                    { 23, 2, 5, "I don't really pay any attention to it. " },
                    { 24, 3, 5, "Nope, I usually play with the sound off." },
                    { 25, 4, 5, "To an extent, it's not a make-or-break deal for me, however." },
                    { 26, 5, 5, "Yes! A good soundtrack can be vital!" },
                    { 27, 1, 6, "Final Fantasy XV" },
                    { 28, 2, 6, "Rise of the Tomb Raider" },
                    { 29, 3, 6, "Fifa 18" },
                    { 30, 4, 6, "Gears Of War" },
                    { 31, 5, 6, "Civilization VI" },
                    { 32, 5, 6, "Candy Crush" },
                    { 33, 1, 7, "I'm not bothered, but I would rather there not be too graphic images and language. " },
                    { 34, 2, 7, "Why is mature content a problem when I only play sports games?" },
                    { 35, 3, 7, "Nope, not at all! I want blood, gore, and plenty of bad language." },
                    { 36, 4, 7, "Yes, definitely. I do not approve of those elements." },
                    { 37, 5, 7, "No, not a problem. I feel there is a time and place for everything." },
                    { 38, 5, 7, "I'm not bothered either way." },
                    { 39, 1, 8, "It's all I do!" },
                    { 40, 2, 8, "I do enjoy my games" },
                    { 41, 3, 8, "Very casual, I hardly ever play." },
                    { 42, 4, 8, "I'm a pretty hardcore gamer." }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "Points", "QuestionId", "Title" },
                values: new object[,]
                {
                    { 43, 5, 8, "I guess I'm a casual gamer. I usually only play sports games. " },
                    { 44, 5, 8, "I love video games and play them whenever I have the time. " },
                    { 45, 1, 9, "Only Pc" },
                    { 46, 2, 9, "Just one that I play on a regular basis. " },
                    { 47, 3, 9, "I have one or two consoles." },
                    { 48, 4, 9, "Consoles? No, I play games on my phone." },
                    { 49, 5, 9, "I have most consoles that have ever been released!" },
                    { 50, 6, 9, "I have plenty of consoles. " },
                    { 51, 1, 10, "13th Warrior" },
                    { 52, 2, 10, "Any Given Sunday" },
                    { 53, 3, 10, "Die Hard" },
                    { 54, 4, 10, "The Da Vinci Code" },
                    { 55, 5, 10, "Lord Of The Rings" },
                    { 56, 6, 10, "The Butterfly Effect" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 56);
        }
    }
}
