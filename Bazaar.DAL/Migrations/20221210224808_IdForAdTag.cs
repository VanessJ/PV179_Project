using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class IdForAdTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "AdTag",
                type: "uniqueidentifier",
                nullable: false);

                migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("5ed6dc85-b8ea-4a2f-bd8f-8bcd9eafdca6"), "Sell" },
                    { new Guid("f56e54fb-5137-458c-a17c-a249c5bbd1f0"), "Animals" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "HasPremium", "LastName", "Level", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("40fd3896-7dbd-4daf-928a-cec82b65e54a"), false, "jozko@gmailol.com", "Jozko", false, "Mrkvicka", 0, "0000000", "TestUser" },
                    { new Guid("e4cfc37f-d11c-4444-9faa-5bb3128ff25e"), false, "ferko@gmailol.com", "Ferko", false, "Priezviskovy", 0, "2020040444", "Feri" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("828a7dc9-b1c0-4edf-92f3-4ed59baca7bf"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("40fd3896-7dbd-4daf-928a-cec82b65e54a") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("40fd3896-7dbd-4daf-928a-cec82b65e54a"), new Guid("e4cfc37f-d11c-4444-9faa-5bb3128ff25e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("17b1b3e5-544c-4e4a-983c-53a18d21584d"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("5e3113f6-13ae-4dc3-8d7e-bf90c6eb42de"), new Guid("828a7dc9-b1c0-4edf-92f3-4ed59baca7bf"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Created", "Id", "Message" },
                values: new object[] { new Guid("828a7dc9-b1c0-4edf-92f3-4ed59baca7bf"), new Guid("e4cfc37f-d11c-4444-9faa-5bb3128ff25e"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("5e3113f6-13ae-4dc3-8d7e-bf90c6eb42de"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("828a7dc9-b1c0-4edf-92f3-4ed59baca7bf"), new Guid("e4cfc37f-d11c-4444-9faa-5bb3128ff25e") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("40fd3896-7dbd-4daf-928a-cec82b65e54a"), new Guid("e4cfc37f-d11c-4444-9faa-5bb3128ff25e") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("5ed6dc85-b8ea-4a2f-bd8f-8bcd9eafdca6"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("f56e54fb-5137-458c-a17c-a249c5bbd1f0"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("828a7dc9-b1c0-4edf-92f3-4ed59baca7bf"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e4cfc37f-d11c-4444-9faa-5bb3128ff25e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("40fd3896-7dbd-4daf-928a-cec82b65e54a"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AdTag");

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
    }
}
