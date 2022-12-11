using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CasdadeDeleteOnTag1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdTag_Tag_TagId",
                table: "AdTag");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("c537c0f6-23ad-4d60-b356-a42d7395ce16"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("275a8efe-5a14-4b5a-ae7d-085e12e348ca"), new Guid("03879945-d09f-40ee-8be8-a6cc7b2c7c13") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("29be54e4-8761-48d8-9bef-0b920ec59d07"), new Guid("03879945-d09f-40ee-8be8-a6cc7b2c7c13") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("a26f214d-a057-49ee-b97b-ad094cc17606"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("d8f787e9-f2cd-49d5-b24d-49ee7150a3f6"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("275a8efe-5a14-4b5a-ae7d-085e12e348ca"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("03879945-d09f-40ee-8be8-a6cc7b2c7c13"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("29be54e4-8761-48d8-9bef-0b920ec59d07"));

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("48ba65b7-0811-4f76-95a9-23a0416fda42"), "Sell" },
                    { new Guid("9701ca57-21b7-4ea4-b947-bef743661fb1"), "Animals" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "HasPremium", "LastName", "Level", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("d561a2e7-e58a-410a-8aea-5fce0a546b6f"), false, "jozko@gmailol.com", "Jozko", false, "Mrkvicka", 0, "0000000", "TestUser" },
                    { new Guid("df4c0d96-955c-4f1b-8302-b55c5dba0f0b"), false, "ferko@gmailol.com", "Ferko", false, "Priezviskovy", 0, "2020040444", "Feri" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("b38235f4-9342-44d7-a365-253186725304"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("d561a2e7-e58a-410a-8aea-5fce0a546b6f") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("d561a2e7-e58a-410a-8aea-5fce0a546b6f"), new Guid("df4c0d96-955c-4f1b-8302-b55c5dba0f0b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("cf189f2b-de4e-4b75-ab01-c88bacdff0f3"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("a7b9395e-0053-49a9-a2e3-a57d203bb4ce"), new Guid("b38235f4-9342-44d7-a365-253186725304"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Id", "Message", "Rejected" },
                values: new object[] { new Guid("b38235f4-9342-44d7-a365-253186725304"), new Guid("df4c0d96-955c-4f1b-8302-b55c5dba0f0b"), true, new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku", false });

            migrationBuilder.AddForeignKey(
                name: "FK_AdTag_Tag_TagId",
                table: "AdTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdTag_Tag_TagId",
                table: "AdTag");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("a7b9395e-0053-49a9-a2e3-a57d203bb4ce"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("b38235f4-9342-44d7-a365-253186725304"), new Guid("df4c0d96-955c-4f1b-8302-b55c5dba0f0b") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("d561a2e7-e58a-410a-8aea-5fce0a546b6f"), new Guid("df4c0d96-955c-4f1b-8302-b55c5dba0f0b") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("48ba65b7-0811-4f76-95a9-23a0416fda42"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("9701ca57-21b7-4ea4-b947-bef743661fb1"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("b38235f4-9342-44d7-a365-253186725304"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("df4c0d96-955c-4f1b-8302-b55c5dba0f0b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d561a2e7-e58a-410a-8aea-5fce0a546b6f"));

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("a26f214d-a057-49ee-b97b-ad094cc17606"), "Animals" },
                    { new Guid("d8f787e9-f2cd-49d5-b24d-49ee7150a3f6"), "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "HasPremium", "LastName", "Level", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("03879945-d09f-40ee-8be8-a6cc7b2c7c13"), false, "ferko@gmailol.com", "Ferko", false, "Priezviskovy", 0, "2020040444", "Feri" },
                    { new Guid("29be54e4-8761-48d8-9bef-0b920ec59d07"), false, "jozko@gmailol.com", "Jozko", false, "Mrkvicka", 0, "0000000", "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("275a8efe-5a14-4b5a-ae7d-085e12e348ca"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("29be54e4-8761-48d8-9bef-0b920ec59d07") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("29be54e4-8761-48d8-9bef-0b920ec59d07"), new Guid("03879945-d09f-40ee-8be8-a6cc7b2c7c13"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("a0ff6132-845d-4843-8550-fc6a9f2a50c6"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("c537c0f6-23ad-4d60-b356-a42d7395ce16"), new Guid("275a8efe-5a14-4b5a-ae7d-085e12e348ca"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Id", "Message", "Rejected" },
                values: new object[] { new Guid("275a8efe-5a14-4b5a-ae7d-085e12e348ca"), new Guid("03879945-d09f-40ee-8be8-a6cc7b2c7c13"), true, new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku", false });

            migrationBuilder.AddForeignKey(
                name: "FK_AdTag_Tag_TagId",
                table: "AdTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
