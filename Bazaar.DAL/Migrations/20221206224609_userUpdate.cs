using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class userUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("99dcaaa9-4756-423e-91a2-a354aad336ec"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("58f68a02-c9b6-42c8-b9af-be5193a53644"), new Guid("25fc850f-5dca-4608-bb79-cd81242bfdff") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("7fc653e2-6b87-4a7d-b34d-e0d0af854528"), new Guid("25fc850f-5dca-4608-bb79-cd81242bfdff") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7e2ef48b-053e-4a6e-80a3-17ea6c47feef"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("98644e76-1757-48b3-839d-7fa3d94238bf"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("58f68a02-c9b6-42c8-b9af-be5193a53644"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("25fc850f-5dca-4608-bb79-cd81242bfdff"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7fc653e2-6b87-4a7d-b34d-e0d0af854528"));

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "User",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "User",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("7e2ef48b-053e-4a6e-80a3-17ea6c47feef"), "Sell" },
                    { new Guid("98644e76-1757-48b3-839d-7fa3d94238bf"), "Animals" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "Roles", "UserName" },
                values: new object[,]
                {
                    { new Guid("25fc850f-5dca-4608-bb79-cd81242bfdff"), false, "ferko@gmailol.com", "Ferko", "Priezviskovy", "supertajneheslo", "2020040444", "User", "Feri" },
                    { new Guid("7fc653e2-6b87-4a7d-b34d-e0d0af854528"), false, "jozko@gmailol.com", "Jozko", "Mrkvicka", "tajneheslo", "0000000", "User", "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("58f68a02-c9b6-42c8-b9af-be5193a53644"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("7fc653e2-6b87-4a7d-b34d-e0d0af854528") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("7fc653e2-6b87-4a7d-b34d-e0d0af854528"), new Guid("25fc850f-5dca-4608-bb79-cd81242bfdff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("95466cc1-ffbf-4045-862d-ee5e5443b7ae"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("99dcaaa9-4756-423e-91a2-a354aad336ec"), new Guid("58f68a02-c9b6-42c8-b9af-be5193a53644"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Created", "Id", "Message" },
                values: new object[] { new Guid("58f68a02-c9b6-42c8-b9af-be5193a53644"), new Guid("25fc850f-5dca-4608-bb79-cd81242bfdff"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku" });
        }
    }
}
