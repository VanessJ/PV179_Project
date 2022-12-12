using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("d7264c1c-0984-4969-b035-6614059f4c06"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumn: "Id",
                keyValue: new Guid("2988a142-d24e-4e67-acef-e20a2ad0cc11"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("caecbd5f-a0ff-4a84-8422-1aea11be8e69"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("46fd7a4d-2f99-4318-845d-fd7f34767fd1"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("5b4e8b7a-1fd1-4c41-aaca-e2912ccfff0a"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("7ba9ed02-e10c-41a3-b0f9-42c8a7da6734"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b0c2a87f-cd01-419c-9dcc-dfd8617382c3"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f55ebeef-f422-4501-a74a-f3410ed63976"));

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("008f6b73-8392-4b46-a4db-b37524c66a4d"), "Animals" },
                    { new Guid("4287170d-f618-4165-8055-58e9f6a54e54"), "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "HasPremium", "LastName", "Level", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("0fbbcd36-84b4-4b0f-83b5-f986a0416cea"), false, "jozko@example.com", "Jozko", false, "Mrkvicka", 0, "0000000", "TestUser" },
                    { new Guid("2257012a-a0cf-4425-93ff-82810feec09a"), false, "ferko@example.com", "Ferko", false, "Priezviskovy", 0, "2020040444", "Feri" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("7d28780b-3739-4c60-8cb1-ca2eddd48256"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("0fbbcd36-84b4-4b0f-83b5-f986a0416cea") });

            migrationBuilder.InsertData(
                table: "AdTag",
                columns: new[] { "Id", "AdId", "TagId" },
                values: new object[,]
                {
                    { new Guid("07374bdb-c894-4247-b86b-0b4c52512fcd"), new Guid("7d28780b-3739-4c60-8cb1-ca2eddd48256"), new Guid("4287170d-f618-4165-8055-58e9f6a54e54") },
                    { new Guid("165a3399-c8b4-4ec2-8949-2cede028bee1"), new Guid("7d28780b-3739-4c60-8cb1-ca2eddd48256"), new Guid("008f6b73-8392-4b46-a4db-b37524c66a4d") }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("1337ad14-de10-4b39-b0a1-d1287d16d7d9"), new Guid("7d28780b-3739-4c60-8cb1-ca2eddd48256"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "Id", "Accepted", "AdId", "Message", "Rejected", "Reviewed", "UserId" },
                values: new object[] { new Guid("cbe04aaf-f674-4663-8a83-13688c739efc"), true, new Guid("7d28780b-3739-4c60-8cb1-ca2eddd48256"), "Mam zaujem o vasu prekrasnu macku", false, false, new Guid("2257012a-a0cf-4425-93ff-82810feec09a") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "AdId", "Descritption", "ReviewedId", "ReviewerId", "Score" },
                values: new object[] { new Guid("804ba4d7-8772-4ef2-8b09-5112e0978ec2"), new Guid("7d28780b-3739-4c60-8cb1-ca2eddd48256"), "Krasna macka, 10/10 spokojnost", new Guid("0fbbcd36-84b4-4b0f-83b5-f986a0416cea"), new Guid("2257012a-a0cf-4425-93ff-82810feec09a"), 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdTag",
                keyColumn: "Id",
                keyValue: new Guid("07374bdb-c894-4247-b86b-0b4c52512fcd"));

            migrationBuilder.DeleteData(
                table: "AdTag",
                keyColumn: "Id",
                keyValue: new Guid("165a3399-c8b4-4ec2-8949-2cede028bee1"));

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("1337ad14-de10-4b39-b0a1-d1287d16d7d9"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumn: "Id",
                keyValue: new Guid("cbe04aaf-f674-4663-8a83-13688c739efc"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("804ba4d7-8772-4ef2-8b09-5112e0978ec2"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("7d28780b-3739-4c60-8cb1-ca2eddd48256"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("008f6b73-8392-4b46-a4db-b37524c66a4d"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("4287170d-f618-4165-8055-58e9f6a54e54"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2257012a-a0cf-4425-93ff-82810feec09a"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("0fbbcd36-84b4-4b0f-83b5-f986a0416cea"));

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("46fd7a4d-2f99-4318-845d-fd7f34767fd1"), "Animals" },
                    { new Guid("5b4e8b7a-1fd1-4c41-aaca-e2912ccfff0a"), "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "HasPremium", "LastName", "Level", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("b0c2a87f-cd01-419c-9dcc-dfd8617382c3"), false, "ferko@gmailol.com", "Ferko", false, "Priezviskovy", 0, "2020040444", "Feri" },
                    { new Guid("f55ebeef-f422-4501-a74a-f3410ed63976"), false, "jozko@gmailol.com", "Jozko", false, "Mrkvicka", 0, "0000000", "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("7ba9ed02-e10c-41a3-b0f9-42c8a7da6734"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("f55ebeef-f422-4501-a74a-f3410ed63976") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("d7264c1c-0984-4969-b035-6614059f4c06"), new Guid("7ba9ed02-e10c-41a3-b0f9-42c8a7da6734"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "Id", "Accepted", "AdId", "Message", "Rejected", "Reviewed", "UserId" },
                values: new object[] { new Guid("2988a142-d24e-4e67-acef-e20a2ad0cc11"), true, new Guid("7ba9ed02-e10c-41a3-b0f9-42c8a7da6734"), "Mam zaujem o vasu prekrasnu macku", false, false, new Guid("b0c2a87f-cd01-419c-9dcc-dfd8617382c3") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "AdId", "Descritption", "ReviewedId", "ReviewerId", "Score" },
                values: new object[] { new Guid("caecbd5f-a0ff-4a84-8422-1aea11be8e69"), new Guid("7ba9ed02-e10c-41a3-b0f9-42c8a7da6734"), "Krasna macka, 10/10 spokojnost", new Guid("f55ebeef-f422-4501-a74a-f3410ed63976"), new Guid("b0c2a87f-cd01-419c-9dcc-dfd8617382c3"), 5 });
        }
    }
}
