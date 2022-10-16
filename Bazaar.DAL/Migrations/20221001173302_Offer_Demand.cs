using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazaar.DAL.Migrations
{
    public partial class Offer_Demand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[] { 2, "ferko@gmail.com", "Ferko", "Priezviskovy", "supertajneheslo", "2020040444", "Feri" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
