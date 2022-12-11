using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AdTagWithoutId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AdTag");

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("01c073ad-83e8-429b-9306-9ae46485f300"), "Sell" },
                    { new Guid("fb9284dd-d0da-439a-a9a0-e3be07860f55"), "Animals" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "HasPremium", "LastName", "Level", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("e5493a8e-7356-45d6-9191-e7ab47a54756"), false, "jozko@gmailol.com", "Jozko", false, "Mrkvicka", 0, "0000000", "TestUser" },
                    { new Guid("f58e5449-9bdc-4ed9-bfec-fdb75232b21e"), false, "ferko@gmailol.com", "Ferko", false, "Priezviskovy", 0, "2020040444", "Feri" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("923a23b7-7f28-41a9-82dd-c74885d3bb82"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("e5493a8e-7356-45d6-9191-e7ab47a54756") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("e5493a8e-7356-45d6-9191-e7ab47a54756"), new Guid("f58e5449-9bdc-4ed9-bfec-fdb75232b21e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("6816ae50-b396-4d2b-9cd0-b71495c04164"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("6c5fea72-fa28-4606-a63e-5fca868827f6"), new Guid("923a23b7-7f28-41a9-82dd-c74885d3bb82"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Created", "Id", "Message" },
                values: new object[] { new Guid("923a23b7-7f28-41a9-82dd-c74885d3bb82"), new Guid("f58e5449-9bdc-4ed9-bfec-fdb75232b21e"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("6c5fea72-fa28-4606-a63e-5fca868827f6"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("923a23b7-7f28-41a9-82dd-c74885d3bb82"), new Guid("f58e5449-9bdc-4ed9-bfec-fdb75232b21e") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("e5493a8e-7356-45d6-9191-e7ab47a54756"), new Guid("f58e5449-9bdc-4ed9-bfec-fdb75232b21e") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("01c073ad-83e8-429b-9306-9ae46485f300"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("fb9284dd-d0da-439a-a9a0-e3be07860f55"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("923a23b7-7f28-41a9-82dd-c74885d3bb82"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f58e5449-9bdc-4ed9-bfec-fdb75232b21e"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e5493a8e-7356-45d6-9191-e7ab47a54756"));

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
        }
    }
}
