using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Reviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("f5db8017-d702-4565-82d3-04c834cede46"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("3ff87307-e7c6-411a-a880-2034815d960a"), new Guid("3cb12878-eebd-42a4-ba57-15f5ce59d14e") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("5b995000-09d8-403c-997b-5aad20df1222"), new Guid("3cb12878-eebd-42a4-ba57-15f5ce59d14e") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("c481ebd9-43cf-4156-9183-afe08f62a9c3"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("d69dee90-1fcd-4e8d-a30f-e3edc2c936e4"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("3ff87307-e7c6-411a-a880-2034815d960a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3cb12878-eebd-42a4-ba57-15f5ce59d14e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5b995000-09d8-403c-997b-5aad20df1222"));

            migrationBuilder.AddColumn<bool>(
                name: "Reviewed",
                table: "Reaction",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("8056ebb5-9fd6-433c-b28d-5533e14b6a3f"), "Animals" },
                    { new Guid("f8de57a3-befa-48ee-ad1f-51b719261801"), "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "HasPremium", "LastName", "Level", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("b45ccbe5-e3ae-4d08-bf76-330419c25959"), false, "jozko@gmailol.com", "Jozko", false, "Mrkvicka", 0, "0000000", "TestUser" },
                    { new Guid("ec64bd2c-79ca-4624-b077-599aa418ecac"), false, "ferko@gmailol.com", "Ferko", false, "Priezviskovy", 0, "2020040444", "Feri" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("69c041b0-a5b7-4842-ac77-be0e245d1cd1"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("b45ccbe5-e3ae-4d08-bf76-330419c25959") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("d120bc1d-fe97-4161-bcc2-4539f0c92f5a"), new Guid("69c041b0-a5b7-4842-ac77-be0e245d1cd1"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Id", "Message", "Rejected", "Reviewed" },
                values: new object[] { new Guid("69c041b0-a5b7-4842-ac77-be0e245d1cd1"), new Guid("ec64bd2c-79ca-4624-b077-599aa418ecac"), true, new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku", false, false });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "AdId", "Descritption", "ReviewedId", "ReviewerId", "Score" },
                values: new object[] { new Guid("e42f5477-9bea-4936-bfd8-3a3cc4d2361d"), new Guid("69c041b0-a5b7-4842-ac77-be0e245d1cd1"), "Krasna macka, 10/10 spokojnost", new Guid("b45ccbe5-e3ae-4d08-bf76-330419c25959"), new Guid("ec64bd2c-79ca-4624-b077-599aa418ecac"), 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReviewerId",
                table: "Review",
                column: "ReviewerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ReviewerId",
                table: "Review");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("d120bc1d-fe97-4161-bcc2-4539f0c92f5a"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("69c041b0-a5b7-4842-ac77-be0e245d1cd1"), new Guid("ec64bd2c-79ca-4624-b077-599aa418ecac") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("e42f5477-9bea-4936-bfd8-3a3cc4d2361d"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("8056ebb5-9fd6-433c-b28d-5533e14b6a3f"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("f8de57a3-befa-48ee-ad1f-51b719261801"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("69c041b0-a5b7-4842-ac77-be0e245d1cd1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ec64bd2c-79ca-4624-b077-599aa418ecac"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b45ccbe5-e3ae-4d08-bf76-330419c25959"));

            migrationBuilder.DropColumn(
                name: "Reviewed",
                table: "Reaction");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                columns: new[] { "ReviewerId", "ReviewedId" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("c481ebd9-43cf-4156-9183-afe08f62a9c3"), "Sell" },
                    { new Guid("d69dee90-1fcd-4e8d-a30f-e3edc2c936e4"), "Animals" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "HasPremium", "LastName", "Level", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("3cb12878-eebd-42a4-ba57-15f5ce59d14e"), false, "ferko@gmailol.com", "Ferko", false, "Priezviskovy", 0, "2020040444", "Feri" },
                    { new Guid("5b995000-09d8-403c-997b-5aad20df1222"), false, "jozko@gmailol.com", "Jozko", false, "Mrkvicka", 0, "0000000", "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("3ff87307-e7c6-411a-a880-2034815d960a"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("5b995000-09d8-403c-997b-5aad20df1222") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("f5db8017-d702-4565-82d3-04c834cede46"), new Guid("3ff87307-e7c6-411a-a880-2034815d960a"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Id", "Message", "Rejected" },
                values: new object[] { new Guid("3ff87307-e7c6-411a-a880-2034815d960a"), new Guid("3cb12878-eebd-42a4-ba57-15f5ce59d14e"), true, new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku", false });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "AdId", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("5b995000-09d8-403c-997b-5aad20df1222"), new Guid("3cb12878-eebd-42a4-ba57-15f5ce59d14e"), new Guid("3ff87307-e7c6-411a-a880-2034815d960a"), "Krasna macka, 10/10 spokojnost", new Guid("0bb5f1b2-51c3-4631-92b6-f787ca9f1faf"), 5 });
        }
    }
}
