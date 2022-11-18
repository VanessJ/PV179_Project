using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class foreignKeyUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("ddc73cb3-7b82-4398-8dc9-f554bdb9e462"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("5a9c4354-9bc0-4d96-8a69-748094eb28a2"), new Guid("aa76b08b-f3cf-4ba6-afd7-9b68cecb3a90") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("038ee4a5-2c93-4373-b275-489057e6932b"), new Guid("aa76b08b-f3cf-4ba6-afd7-9b68cecb3a90") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("8852f5af-2f9c-42b5-ada3-b290cadfaf5d"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("b6adf270-55b5-4501-8a58-8306eb92c935"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("5a9c4354-9bc0-4d96-8a69-748094eb28a2"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("aa76b08b-f3cf-4ba6-afd7-9b68cecb3a90"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("038ee4a5-2c93-4373-b275-489057e6932b"));

            migrationBuilder.AddColumn<bool>(
                name: "Banned",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Reaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("34b95bbd-9ad6-4b14-b1ee-0c92fa1f1812"), "Animals" },
                    { new Guid("9694ac3c-820e-45bd-a03c-816c29f0d58c"), "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "LastName", "Level", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("3470b296-9575-49b6-9944-1217e099e9e0"), false, "ferko@gmailol.com", "Ferko", "Priezviskovy", 0, "supertajneheslo", "2020040444", "Feri" },
                    { new Guid("a52223df-f7e0-468f-9c75-46ed8e9b1e53"), false, "jozko@gmailol.com", "Jozko", "Mrkvicka", 0, "tajneheslo", "0000000", "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("347c55d3-6415-43dd-9fe5-9e4d45c2b955"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("a52223df-f7e0-468f-9c75-46ed8e9b1e53") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("a52223df-f7e0-468f-9c75-46ed8e9b1e53"), new Guid("3470b296-9575-49b6-9944-1217e099e9e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("928b4c95-9878-41e2-904a-6ba97439f86c"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("5da62c31-9710-43f3-bc63-f120f68502ca"), new Guid("347c55d3-6415-43dd-9fe5-9e4d45c2b955"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Created", "Id", "Message" },
                values: new object[] { new Guid("347c55d3-6415-43dd-9fe5-9e4d45c2b955"), new Guid("3470b296-9575-49b6-9944-1217e099e9e0"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("5da62c31-9710-43f3-bc63-f120f68502ca"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("347c55d3-6415-43dd-9fe5-9e4d45c2b955"), new Guid("3470b296-9575-49b6-9944-1217e099e9e0") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("a52223df-f7e0-468f-9c75-46ed8e9b1e53"), new Guid("3470b296-9575-49b6-9944-1217e099e9e0") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("34b95bbd-9ad6-4b14-b1ee-0c92fa1f1812"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("9694ac3c-820e-45bd-a03c-816c29f0d58c"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("347c55d3-6415-43dd-9fe5-9e4d45c2b955"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3470b296-9575-49b6-9944-1217e099e9e0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a52223df-f7e0-468f-9c75-46ed8e9b1e53"));

            migrationBuilder.DropColumn(
                name: "Banned",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Reaction");

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("8852f5af-2f9c-42b5-ada3-b290cadfaf5d"), "Animals" },
                    { new Guid("b6adf270-55b5-4501-8a58-8306eb92c935"), "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Level", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("038ee4a5-2c93-4373-b275-489057e6932b"), "jozko@gmailol.com", "Jozko", "Mrkvicka", 0, "tajneheslo", "0000000", "TestUser" },
                    { new Guid("aa76b08b-f3cf-4ba6-afd7-9b68cecb3a90"), "ferko@gmailol.com", "Ferko", "Priezviskovy", 0, "supertajneheslo", "2020040444", "Feri" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("5a9c4354-9bc0-4d96-8a69-748094eb28a2"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("038ee4a5-2c93-4373-b275-489057e6932b") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("038ee4a5-2c93-4373-b275-489057e6932b"), new Guid("aa76b08b-f3cf-4ba6-afd7-9b68cecb3a90"), "Krasna macka, 10/10 spokojnost", new Guid("a58e961a-e4a8-43c9-b0d4-89360c2594a3"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("ddc73cb3-7b82-4398-8dc9-f554bdb9e462"), new Guid("5a9c4354-9bc0-4d96-8a69-748094eb28a2"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Id", "Message" },
                values: new object[] { new Guid("5a9c4354-9bc0-4d96-8a69-748094eb28a2"), new Guid("aa76b08b-f3cf-4ba6-afd7-9b68cecb3a90"), true, new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku" });
        }
    }
}
