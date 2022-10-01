using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaarDAL.Migrations
{
    public partial class tagseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagId", "TagName" },
                values: new object[] { 2, "Sell" });

            migrationBuilder.InsertData(
                table: "AdTag",
                columns: new[] { "AdId", "TagId" },
                values: new object[] { 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdTag",
                keyColumns: new[] { "AdId", "TagId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "TagId",
                keyValue: 2);
        }
    }
}
