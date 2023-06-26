using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News_Reviews.Data.Migrations
{
    public partial class FillGamesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "PC" },
                    { 2, "Playstation" },
                    { 3, "Xbox" },
                    { 4, "Phone" },
                    { 5, "Nintendo" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "GenreId", "Name", "PlatformId", "PublishDate", "PublisherId" },
                values: new object[,]
                {
                    { 1, 2, "Call of Duty", 1, new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 5, "Assansin's creed", 1, new DateTime(2007, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 6, "God of War", 2, new DateTime(2005, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 1, "Elden ring", 3, new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 1, "Bloodborn", 2, new DateTime(2015, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 6, 1, "The witcher 3", 1, new DateTime(2015, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 7, 3, "Super Mario", 5, new DateTime(2017, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, 2, "Call of Duty: Mobile", 4, new DateTime(2019, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, 3, "Among us", 4, new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, 3, "Far Cry 6", 1, new DateTime(2021, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, 1, "Dark Souls", 1, new DateTime(2016, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
