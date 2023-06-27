using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News_Reviews.Data.Migrations
{
    public partial class UpdateNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlatformId",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_News_PlatformId",
                table: "News",
                column: "PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Platforms_PlatformId",
                table: "News",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Platforms_PlatformId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_PlatformId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "News");
        }
    }
}
