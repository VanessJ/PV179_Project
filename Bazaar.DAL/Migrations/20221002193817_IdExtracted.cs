using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazaar.DAL.Migrations
{
    public partial class IdExtracted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Tag",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Image",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AdId",
                table: "Ad",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "TagName",
                table: "Tag",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Image",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Ad",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tag",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Image",
                newName: "ImageId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ad",
                newName: "AdId");

            migrationBuilder.AlterColumn<string>(
                name: "TagName",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Image",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Ad",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
