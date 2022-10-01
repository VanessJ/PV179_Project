using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BazaarDAL.Migrations
{
    public partial class AdSeedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "AdId", "Description", "IsPremium", "IsValid", "Price", "Title", "UserId", "isOffer" },
                values: new object[] { 1, "Je velmi zlata, zbavte ma jej, prosim", false, true, 50, "Predam macku", 1, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "AdId",
                keyValue: 1);
        }
    }
}
