using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AdTagWithId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("501105f9-b194-4560-9f0c-1adb8b472c6c"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("ba8a90b8-c1dc-4cdf-ab85-5ce594062c80"), new Guid("12638220-3fe3-4bb3-80ed-658d9a9009d7") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("391a1b1e-ce2d-43c4-a6b1-85ebdc5b79aa"), new Guid("12638220-3fe3-4bb3-80ed-658d9a9009d7") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("056c611a-6dba-4a80-ac00-ec76ba264a31"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("9b8e06e0-77da-419c-acb2-076f6c48715f"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("ba8a90b8-c1dc-4cdf-ab85-5ce594062c80"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("12638220-3fe3-4bb3-80ed-658d9a9009d7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("391a1b1e-ce2d-43c4-a6b1-85ebdc5b79aa"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AdTag",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("76670945-f5a5-4121-8c4d-433c18d6b45b"), "Sell" },
                    { new Guid("e266b184-bf2c-4e65-98e4-d9eab52d5462"), "Animals" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "HasPremium", "LastName", "Level", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("6e5b3916-ef43-4ad7-bacb-b98464a7c203"), false, "jozko@gmailol.com", "Jozko", false, "Mrkvicka", 0, "0000000", "TestUser" },
                    { new Guid("f52f09a3-450e-459d-a798-90bd988840f7"), false, "ferko@gmailol.com", "Ferko", false, "Priezviskovy", 0, "2020040444", "Feri" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("ee7feffa-1d3a-4124-9cb7-073ffae1b258"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("6e5b3916-ef43-4ad7-bacb-b98464a7c203") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("6e5b3916-ef43-4ad7-bacb-b98464a7c203"), new Guid("f52f09a3-450e-459d-a798-90bd988840f7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("a18c4f6a-e395-4b0e-8c07-56a05de0dab7"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("92174323-a2f4-4e1b-99c6-eb3040a91a5f"), new Guid("ee7feffa-1d3a-4124-9cb7-073ffae1b258"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Id", "Message", "Rejected" },
                values: new object[] { new Guid("ee7feffa-1d3a-4124-9cb7-073ffae1b258"), new Guid("f52f09a3-450e-459d-a798-90bd988840f7"), true, new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("92174323-a2f4-4e1b-99c6-eb3040a91a5f"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("ee7feffa-1d3a-4124-9cb7-073ffae1b258"), new Guid("f52f09a3-450e-459d-a798-90bd988840f7") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("6e5b3916-ef43-4ad7-bacb-b98464a7c203"), new Guid("f52f09a3-450e-459d-a798-90bd988840f7") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("76670945-f5a5-4121-8c4d-433c18d6b45b"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("e266b184-bf2c-4e65-98e4-d9eab52d5462"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("ee7feffa-1d3a-4124-9cb7-073ffae1b258"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f52f09a3-450e-459d-a798-90bd988840f7"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6e5b3916-ef43-4ad7-bacb-b98464a7c203"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AdTag");

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("056c611a-6dba-4a80-ac00-ec76ba264a31"), "Animals" },
                    { new Guid("9b8e06e0-77da-419c-acb2-076f6c48715f"), "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "HasPremium", "LastName", "Level", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("12638220-3fe3-4bb3-80ed-658d9a9009d7"), false, "ferko@gmailol.com", "Ferko", false, "Priezviskovy", 0, "2020040444", "Feri" },
                    { new Guid("391a1b1e-ce2d-43c4-a6b1-85ebdc5b79aa"), false, "jozko@gmailol.com", "Jozko", false, "Mrkvicka", 0, "0000000", "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("ba8a90b8-c1dc-4cdf-ab85-5ce594062c80"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("391a1b1e-ce2d-43c4-a6b1-85ebdc5b79aa") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("391a1b1e-ce2d-43c4-a6b1-85ebdc5b79aa"), new Guid("12638220-3fe3-4bb3-80ed-658d9a9009d7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("9aa51540-7d1f-48d2-a510-c675ecab605a"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("501105f9-b194-4560-9f0c-1adb8b472c6c"), new Guid("ba8a90b8-c1dc-4cdf-ab85-5ce594062c80"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Id", "Message", "Rejected" },
                values: new object[] { new Guid("ba8a90b8-c1dc-4cdf-ab85-5ce594062c80"), new Guid("12638220-3fe3-4bb3-80ed-658d9a9009d7"), true, new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku", false });
        }
    }
}
