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
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("617db75e-465f-4117-992f-8e41b9939ff9"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("6505480b-ec94-48ef-88e5-c85f19027411"), new Guid("c81bf26a-4ddf-4440-91c9-3d19f7c0fe07") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("fe5f5529-8962-4b7d-9c59-59d1234d51ab"), new Guid("c81bf26a-4ddf-4440-91c9-3d19f7c0fe07") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("a5eae206-0d44-4cc8-a68a-1de60d7e1bbd"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("d0e774dc-24b2-4fa1-9b3c-5f65a92624e1"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("6505480b-ec94-48ef-88e5-c85f19027411"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c81bf26a-4ddf-4440-91c9-3d19f7c0fe07"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fe5f5529-8962-4b7d-9c59-59d1234d51ab"));

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("7abd38d2-756f-4a59-b734-f0282437952d"), "Sell" },
                    { new Guid("fef91a94-758f-4ab0-a76b-615c758413d3"), "Animals" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "HasPremium", "LastName", "Level", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("7bbb5053-de28-4902-9104-7b3bd73ecfa5"), false, "ferko@gmailol.com", "Ferko", false, "Priezviskovy", 0, "2020040444", "Feri" },
                    { new Guid("ed794a69-c3a5-40f0-9fd8-f05461602b6a"), false, "jozko@gmailol.com", "Jozko", false, "Mrkvicka", 0, "0000000", "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("785e74ea-9ec0-4ba8-a520-4591f4522577"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("ed794a69-c3a5-40f0-9fd8-f05461602b6a") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("ed794a69-c3a5-40f0-9fd8-f05461602b6a"), new Guid("7bbb5053-de28-4902-9104-7b3bd73ecfa5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("2bb11e8b-ee9d-41d1-8bca-25f6402da05f"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("af79af6e-7877-4581-b990-5e6c17fbf349"), new Guid("785e74ea-9ec0-4ba8-a520-4591f4522577"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Id", "Message", "Rejected" },
                values: new object[] { new Guid("785e74ea-9ec0-4ba8-a520-4591f4522577"), new Guid("7bbb5053-de28-4902-9104-7b3bd73ecfa5"), true, new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("af79af6e-7877-4581-b990-5e6c17fbf349"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("785e74ea-9ec0-4ba8-a520-4591f4522577"), new Guid("7bbb5053-de28-4902-9104-7b3bd73ecfa5") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("ed794a69-c3a5-40f0-9fd8-f05461602b6a"), new Guid("7bbb5053-de28-4902-9104-7b3bd73ecfa5") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7abd38d2-756f-4a59-b734-f0282437952d"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("fef91a94-758f-4ab0-a76b-615c758413d3"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("785e74ea-9ec0-4ba8-a520-4591f4522577"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7bbb5053-de28-4902-9104-7b3bd73ecfa5"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ed794a69-c3a5-40f0-9fd8-f05461602b6a"));

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("a5eae206-0d44-4cc8-a68a-1de60d7e1bbd"), "Animals" },
                    { new Guid("d0e774dc-24b2-4fa1-9b3c-5f65a92624e1"), "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "HasPremium", "LastName", "Level", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("c81bf26a-4ddf-4440-91c9-3d19f7c0fe07"), false, "ferko@gmailol.com", "Ferko", false, "Priezviskovy", 0, "2020040444", "Feri" },
                    { new Guid("fe5f5529-8962-4b7d-9c59-59d1234d51ab"), false, "jozko@gmailol.com", "Jozko", false, "Mrkvicka", 0, "0000000", "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("6505480b-ec94-48ef-88e5-c85f19027411"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("fe5f5529-8962-4b7d-9c59-59d1234d51ab") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("fe5f5529-8962-4b7d-9c59-59d1234d51ab"), new Guid("c81bf26a-4ddf-4440-91c9-3d19f7c0fe07"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("707a7639-e30e-41e2-9151-150ab5e30a50"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("617db75e-465f-4117-992f-8e41b9939ff9"), new Guid("6505480b-ec94-48ef-88e5-c85f19027411"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Id", "Message", "Rejected" },
                values: new object[] { new Guid("6505480b-ec94-48ef-88e5-c85f19027411"), new Guid("c81bf26a-4ddf-4440-91c9-3d19f7c0fe07"), true, new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku", false });
        }
    }
}
