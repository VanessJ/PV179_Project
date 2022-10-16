using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazaar.DAL.Migrations
{
    public partial class TagImgSeedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "ImageId", "AdId", "PathToImg", "Title" },
                values: new object[] { 1, 1, "\\obrazokmacky.jpg", "Milovana macka" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagId", "TagName" },
                values: new object[] { 1, "Animals" });

            migrationBuilder.InsertData(
                table: "AdTag",
                columns: new[] { "AdId", "TagId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdTag",
                keyColumns: new[] { "AdId", "TagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "ImageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 1);
        }
    }
}
