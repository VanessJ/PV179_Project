using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("5342d488-1d06-4821-a5f4-adda7be45fb2"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("44fb4726-7979-4861-8f8a-df18360df1df"), new Guid("daf8852f-9201-44ef-9edb-1719958eaa74") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("9f867b57-47a5-47a6-8c8d-dfa866b519a3"), new Guid("daf8852f-9201-44ef-9edb-1719958eaa74") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("05d6e513-d181-4d04-83b5-e67d0c245b36"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("50c33b42-cad4-4d36-a51c-84d821e961bc"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("44fb4726-7979-4861-8f8a-df18360df1df"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("daf8852f-9201-44ef-9edb-1719958eaa74"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9f867b57-47a5-47a6-8c8d-dfa866b519a3"));

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
                    { new Guid("878c72ab-db08-47b6-a3a8-d3e88c2ec697"), "Animals" },
                    { new Guid("ce48fc8e-c99b-4715-ad80-f0e99c296a58"), "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "Roles", "UserName" },
                values: new object[,]
                {
                    { new Guid("40678c71-cd5f-4a6c-bd00-442da8a88591"), false, "ferko@gmailol.com", "Ferko", "Priezviskovy", "supertajneheslo", "2020040444", "User", "Feri" },
                    { new Guid("f719643c-854e-4d30-913b-4accccfbbf2c"), false, "jozko@gmailol.com", "Jozko", "Mrkvicka", "tajneheslo", "0000000", "User", "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("eeaa9ac3-bd7f-4d43-85a1-ccbacb49e536"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("f719643c-854e-4d30-913b-4accccfbbf2c") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("f719643c-854e-4d30-913b-4accccfbbf2c"), new Guid("40678c71-cd5f-4a6c-bd00-442da8a88591"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("c738cc1d-8525-41b7-b2b9-5882813ae2d9"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("2e44f1f6-19a1-4481-8e32-a5920711f0ae"), new Guid("eeaa9ac3-bd7f-4d43-85a1-ccbacb49e536"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Created", "Id", "Message" },
                values: new object[] { new Guid("eeaa9ac3-bd7f-4d43-85a1-ccbacb49e536"), new Guid("40678c71-cd5f-4a6c-bd00-442da8a88591"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("2e44f1f6-19a1-4481-8e32-a5920711f0ae"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("eeaa9ac3-bd7f-4d43-85a1-ccbacb49e536"), new Guid("40678c71-cd5f-4a6c-bd00-442da8a88591") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("f719643c-854e-4d30-913b-4accccfbbf2c"), new Guid("40678c71-cd5f-4a6c-bd00-442da8a88591") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("878c72ab-db08-47b6-a3a8-d3e88c2ec697"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("ce48fc8e-c99b-4715-ad80-f0e99c296a58"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("eeaa9ac3-bd7f-4d43-85a1-ccbacb49e536"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("40678c71-cd5f-4a6c-bd00-442da8a88591"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f719643c-854e-4d30-913b-4accccfbbf2c"));

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "User");

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("05d6e513-d181-4d04-83b5-e67d0c245b36"), "Sell" },
                    { new Guid("50c33b42-cad4-4d36-a51c-84d821e961bc"), "Animals" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("9f867b57-47a5-47a6-8c8d-dfa866b519a3"), false, "jozko@gmailol.com", "Jozko", "Mrkvicka", "tajneheslo", "0000000", "TestUser" },
                    { new Guid("daf8852f-9201-44ef-9edb-1719958eaa74"), false, "ferko@gmailol.com", "Ferko", "Priezviskovy", "supertajneheslo", "2020040444", "Feri" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("44fb4726-7979-4861-8f8a-df18360df1df"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("9f867b57-47a5-47a6-8c8d-dfa866b519a3") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("9f867b57-47a5-47a6-8c8d-dfa866b519a3"), new Guid("daf8852f-9201-44ef-9edb-1719958eaa74"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("b0f6ca32-0b90-45be-b999-8101303f8c49"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("5342d488-1d06-4821-a5f4-adda7be45fb2"), new Guid("44fb4726-7979-4861-8f8a-df18360df1df"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Created", "Id", "Message" },
                values: new object[] { new Guid("44fb4726-7979-4861-8f8a-df18360df1df"), new Guid("daf8852f-9201-44ef-9edb-1719958eaa74"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku" });
        }
    }
}
