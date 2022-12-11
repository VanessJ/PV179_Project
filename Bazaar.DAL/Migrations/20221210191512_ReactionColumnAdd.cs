using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ReactionColumnAdd : Migration
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

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Reaction");

            migrationBuilder.AddColumn<bool>(
                name: "Rejected",
                table: "Reaction",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Rejected",
                table: "Reaction");

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
