using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class userUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("896216b3-812b-4cdd-b99f-e8a6fb7b327d"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("4990a474-6b4f-45b9-bf6d-aa6921eae5f4"), new Guid("fd155d22-21c0-426b-9c2b-8a78976e913e") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("64c37eb0-d072-4def-a0c1-df1799d290d5"), new Guid("fd155d22-21c0-426b-9c2b-8a78976e913e") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("952e8a5f-8f21-4d7d-9b8b-738702ef43b0"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("bfdb7ff3-aff0-41d0-b090-8d436b566eaa"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("4990a474-6b4f-45b9-bf6d-aa6921eae5f4"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fd155d22-21c0-426b-9c2b-8a78976e913e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("64c37eb0-d072-4def-a0c1-df1799d290d5"));

            migrationBuilder.AddColumn<bool>(
                name: "HasPremium",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("4891dfce-ec77-47a4-8f24-76ee01551e93"), "Animals" },
                    { new Guid("7e666447-0571-4d21-92f5-5300ccd2cb11"), "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "HasPremium", "LastName", "Level", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("a8bfd873-99cb-44eb-8a7f-bad963fe947f"), false, "ferko@gmailol.com", "Ferko", false, "Priezviskovy", 0, "2020040444", "Feri" },
                    { new Guid("decb7217-30ba-4b6e-bfeb-b17ccf228633"), false, "jozko@gmailol.com", "Jozko", false, "Mrkvicka", 0, "0000000", "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("dba16985-d949-44a7-bf12-fb681120ad52"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("decb7217-30ba-4b6e-bfeb-b17ccf228633") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("decb7217-30ba-4b6e-bfeb-b17ccf228633"), new Guid("a8bfd873-99cb-44eb-8a7f-bad963fe947f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("c14febdd-c062-44d6-b68d-515e3f118f19"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("d454724e-756b-43e0-8bf0-752c265f186c"), new Guid("dba16985-d949-44a7-bf12-fb681120ad52"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Created", "Id", "Message" },
                values: new object[] { new Guid("dba16985-d949-44a7-bf12-fb681120ad52"), new Guid("a8bfd873-99cb-44eb-8a7f-bad963fe947f"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("d454724e-756b-43e0-8bf0-752c265f186c"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("dba16985-d949-44a7-bf12-fb681120ad52"), new Guid("a8bfd873-99cb-44eb-8a7f-bad963fe947f") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("decb7217-30ba-4b6e-bfeb-b17ccf228633"), new Guid("a8bfd873-99cb-44eb-8a7f-bad963fe947f") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("4891dfce-ec77-47a4-8f24-76ee01551e93"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7e666447-0571-4d21-92f5-5300ccd2cb11"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("dba16985-d949-44a7-bf12-fb681120ad52"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a8bfd873-99cb-44eb-8a7f-bad963fe947f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("decb7217-30ba-4b6e-bfeb-b17ccf228633"));

            migrationBuilder.DropColumn(
                name: "HasPremium",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "User");

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("952e8a5f-8f21-4d7d-9b8b-738702ef43b0"), "Animals" },
                    { new Guid("bfdb7ff3-aff0-41d0-b090-8d436b566eaa"), "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "LastName", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("64c37eb0-d072-4def-a0c1-df1799d290d5"), false, "jozko@gmailol.com", "Jozko", "Mrkvicka", "0000000", "TestUser" },
                    { new Guid("fd155d22-21c0-426b-9c2b-8a78976e913e"), false, "ferko@gmailol.com", "Ferko", "Priezviskovy", "2020040444", "Feri" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("4990a474-6b4f-45b9-bf6d-aa6921eae5f4"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("64c37eb0-d072-4def-a0c1-df1799d290d5") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("64c37eb0-d072-4def-a0c1-df1799d290d5"), new Guid("fd155d22-21c0-426b-9c2b-8a78976e913e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("9137342f-49b3-495d-8d18-aa0adfb490c2"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("896216b3-812b-4cdd-b99f-e8a6fb7b327d"), new Guid("4990a474-6b4f-45b9-bf6d-aa6921eae5f4"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Created", "Id", "Message" },
                values: new object[] { new Guid("4990a474-6b4f-45b9-bf6d-aa6921eae5f4"), new Guid("fd155d22-21c0-426b-9c2b-8a78976e913e"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku" });
        }
    }
}
