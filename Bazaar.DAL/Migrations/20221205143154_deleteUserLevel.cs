using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class deleteUserLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("f6504fa4-7d18-4e40-a844-1b9ec88b6a54"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("e73c3dc9-9744-4fa6-a40c-788c19893ca3"), new Guid("67943a2e-28de-4111-b124-e2811e84fb27") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("b6aad1d3-a35c-4c3b-8e99-2a34963699fc"), new Guid("67943a2e-28de-4111-b124-e2811e84fb27") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("323b300f-e4de-4e29-8b33-47bb6668c78b"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("ec77b015-a323-4602-9170-af30de10b89d"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("e73c3dc9-9744-4fa6-a40c-788c19893ca3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("67943a2e-28de-4111-b124-e2811e84fb27"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b6aad1d3-a35c-4c3b-8e99-2a34963699fc"));

            migrationBuilder.DropColumn(
                name: "Level",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("323b300f-e4de-4e29-8b33-47bb6668c78b"), "Animals" },
                    { new Guid("ec77b015-a323-4602-9170-af30de10b89d"), "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "LastName", "Level", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("67943a2e-28de-4111-b124-e2811e84fb27"), false, "ferko@gmailol.com", "Ferko", "Priezviskovy", 0, "supertajneheslo", "2020040444", "Feri" },
                    { new Guid("b6aad1d3-a35c-4c3b-8e99-2a34963699fc"), false, "jozko@gmailol.com", "Jozko", "Mrkvicka", 0, "tajneheslo", "0000000", "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("e73c3dc9-9744-4fa6-a40c-788c19893ca3"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("b6aad1d3-a35c-4c3b-8e99-2a34963699fc") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("b6aad1d3-a35c-4c3b-8e99-2a34963699fc"), new Guid("67943a2e-28de-4111-b124-e2811e84fb27"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("46e2bd5a-6280-4f7e-8af4-b10e477f38b2"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("f6504fa4-7d18-4e40-a844-1b9ec88b6a54"), new Guid("e73c3dc9-9744-4fa6-a40c-788c19893ca3"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Created", "Id", "Message" },
                values: new object[] { new Guid("e73c3dc9-9744-4fa6-a40c-788c19893ca3"), new Guid("67943a2e-28de-4111-b124-e2811e84fb27"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku" });
        }
    }
}
