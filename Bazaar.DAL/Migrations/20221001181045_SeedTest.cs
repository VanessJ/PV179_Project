using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazaar.DAL.Migrations
{
    public partial class SeedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Message" },
                values: new object[] { 1, 2, "Mam zaujem o vasu prekrasnu macku" });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Descritption", "Score" },
                values: new object[] { 1, 2, "Krasna macka, 10/10 spokojnost", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { 1, 2 });
        }
    }
}
