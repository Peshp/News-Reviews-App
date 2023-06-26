using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News_Reviews.Data.Migrations
{
    public partial class UpdateGameEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Platforms_Games_GameId",
                table: "Platforms");

            migrationBuilder.DropTable(
                name: "GameGenre");

            migrationBuilder.DropIndex(
                name: "IX_Platforms_GameId",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Platforms");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlatformId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "RPG" },
                    { 2, "Shooter" },
                    { 3, "Puzzle" },
                    { 4, "Horror" },
                    { 5, "Stealth" },
                    { 6, "Action" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlatformId",
                table: "Games",
                column: "PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Platforms_PlatformId",
                table: "Games",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_GenreId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Platforms_PlatformId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_GenreId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_PlatformId",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Platforms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameGenre",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenre", x => new { x.GamesId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_GameGenre_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_GameId",
                table: "Platforms",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameGenre_GenresId",
                table: "GameGenre",
                column: "GenresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Platforms_Games_GameId",
                table: "Platforms",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
