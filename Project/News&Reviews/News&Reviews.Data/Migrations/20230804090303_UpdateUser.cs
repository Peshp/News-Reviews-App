using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News_Reviews.Data.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Themes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Themes_ApplicationUserId",
                table: "Themes",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Themes_AspNetUsers_ApplicationUserId",
                table: "Themes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Themes_AspNetUsers_ApplicationUserId",
                table: "Themes");

            migrationBuilder.DropIndex(
                name: "IX_Themes_ApplicationUserId",
                table: "Themes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Themes");
        }
    }
}
