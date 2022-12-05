using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class foreignKeyUpdated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("5da62c31-9710-43f3-bc63-f120f68502ca"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("347c55d3-6415-43dd-9fe5-9e4d45c2b955"), new Guid("3470b296-9575-49b6-9944-1217e099e9e0") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("a52223df-f7e0-468f-9c75-46ed8e9b1e53"), new Guid("3470b296-9575-49b6-9944-1217e099e9e0") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("34b95bbd-9ad6-4b14-b1ee-0c92fa1f1812"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("9694ac3c-820e-45bd-a03c-816c29f0d58c"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("347c55d3-6415-43dd-9fe5-9e4d45c2b955"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3470b296-9575-49b6-9944-1217e099e9e0"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a52223df-f7e0-468f-9c75-46ed8e9b1e53"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("34b95bbd-9ad6-4b14-b1ee-0c92fa1f1812"), "Animals" },
                    { new Guid("9694ac3c-820e-45bd-a03c-816c29f0d58c"), "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "LastName", "Level", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("3470b296-9575-49b6-9944-1217e099e9e0"), false, "ferko@gmailol.com", "Ferko", "Priezviskovy", 0, "supertajneheslo", "2020040444", "Feri" },
                    { new Guid("a52223df-f7e0-468f-9c75-46ed8e9b1e53"), false, "jozko@gmailol.com", "Jozko", "Mrkvicka", 0, "tajneheslo", "0000000", "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("347c55d3-6415-43dd-9fe5-9e4d45c2b955"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("a52223df-f7e0-468f-9c75-46ed8e9b1e53") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("a52223df-f7e0-468f-9c75-46ed8e9b1e53"), new Guid("3470b296-9575-49b6-9944-1217e099e9e0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("928b4c95-9878-41e2-904a-6ba97439f86c"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("5da62c31-9710-43f3-bc63-f120f68502ca"), new Guid("347c55d3-6415-43dd-9fe5-9e4d45c2b955"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Created", "Id", "Message" },
                values: new object[] { new Guid("347c55d3-6415-43dd-9fe5-9e4d45c2b955"), new Guid("3470b296-9575-49b6-9944-1217e099e9e0"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku" });
        }
    }
}
