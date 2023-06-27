using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News_Reviews.Data.Migrations
{
    public partial class PlatformUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "PlatformId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PlatformId",
                table: "Reviews",
                column: "PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Platforms_PlatformId",
                table: "Reviews",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Platforms_PlatformId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_PlatformId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Reviews");

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
