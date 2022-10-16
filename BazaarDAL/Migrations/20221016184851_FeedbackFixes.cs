using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazaar.DAL.Migrations
{
    public partial class FeedbackFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PathToImg",
                table: "Image",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "isOffer",
                table: "Ad",
                newName: "IsOffer");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "jozko@gmailol.com");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "ferko@gmailol.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Image",
                newName: "PathToImg");

            migrationBuilder.RenameColumn(
                name: "IsOffer",
                table: "Ad",
                newName: "isOffer");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "jozko@gmail.com");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "ferko@gmail.com");
        }
    }
}
