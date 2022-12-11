using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class TagDeleteCascade : Migration
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

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("324e9fc0-69cc-4870-b1ff-c6eb6178f559"), "Animals" },
                    { new Guid("fc1ea417-a670-4a83-9d94-8708de15ee6e"), "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "HasPremium", "LastName", "Level", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("4ddd4934-ed7a-4224-a4e2-5c42f9843de2"), false, "jozko@gmailol.com", "Jozko", false, "Mrkvicka", 0, "0000000", "TestUser" },
                    { new Guid("b41143c1-358b-455c-bea8-08b98777a789"), false, "ferko@gmailol.com", "Ferko", false, "Priezviskovy", 0, "2020040444", "Feri" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("00954f0c-27ba-46dd-bce1-aeea334cf5e0"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("4ddd4934-ed7a-4224-a4e2-5c42f9843de2") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("4ddd4934-ed7a-4224-a4e2-5c42f9843de2"), new Guid("b41143c1-358b-455c-bea8-08b98777a789"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("08b14255-f584-4273-a37b-63e696c9c491"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("7728d5f2-b8f5-4473-8a18-fafb522082bb"), new Guid("00954f0c-27ba-46dd-bce1-aeea334cf5e0"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Created", "Id", "Message" },
                values: new object[] { new Guid("00954f0c-27ba-46dd-bce1-aeea334cf5e0"), new Guid("b41143c1-358b-455c-bea8-08b98777a789"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku" });

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
                keyValue: new Guid("7728d5f2-b8f5-4473-8a18-fafb522082bb"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("00954f0c-27ba-46dd-bce1-aeea334cf5e0"), new Guid("b41143c1-358b-455c-bea8-08b98777a789") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("4ddd4934-ed7a-4224-a4e2-5c42f9843de2"), new Guid("b41143c1-358b-455c-bea8-08b98777a789") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("324e9fc0-69cc-4870-b1ff-c6eb6178f559"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("fc1ea417-a670-4a83-9d94-8708de15ee6e"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("00954f0c-27ba-46dd-bce1-aeea334cf5e0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b41143c1-358b-455c-bea8-08b98777a789"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("4ddd4934-ed7a-4224-a4e2-5c42f9843de2"));

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
