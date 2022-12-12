using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FKmagic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ad_User_UserId",
                table: "Ad");

            migrationBuilder.DropForeignKey(
                name: "FK_AdTag_Ad_AdId",
                table: "AdTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Ad_AdId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Reaction_Ad_AdId",
                table: "Reaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Reaction_User_UserId",
                table: "Reaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Ad_AdId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_ReviewedId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_ReviewerId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reaction",
                table: "Reaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdTag",
                table: "AdTag");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("d120bc1d-fe97-4161-bcc2-4539f0c92f5a"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("69c041b0-a5b7-4842-ac77-be0e245d1cd1"), new Guid("ec64bd2c-79ca-4624-b077-599aa418ecac") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("e42f5477-9bea-4936-bfd8-3a3cc4d2361d"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("8056ebb5-9fd6-433c-b28d-5533e14b6a3f"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("f8de57a3-befa-48ee-ad1f-51b719261801"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("69c041b0-a5b7-4842-ac77-be0e245d1cd1"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ec64bd2c-79ca-4624-b077-599aa418ecac"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("b45ccbe5-e3ae-4d08-bf76-330419c25959"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reaction",
                table: "Reaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdTag",
                table: "AdTag",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_AdId",
                table: "Reaction",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_AdTag_TagId",
                table: "AdTag",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_User_UserId",
                table: "Ad",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdTag_Ad_AdId",
                table: "AdTag",
                column: "AdId",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Ad_AdId",
                table: "Image",
                column: "AdId",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reaction_Ad_AdId",
                table: "Reaction",
                column: "AdId",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reaction_User_UserId",
                table: "Reaction",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Ad_AdId",
                table: "Review",
                column: "AdId",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_ReviewedId",
                table: "Review",
                column: "ReviewedId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_ReviewerId",
                table: "Review",
                column: "ReviewerId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ad_User_UserId",
                table: "Ad");

            migrationBuilder.DropForeignKey(
                name: "FK_AdTag_Ad_AdId",
                table: "AdTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Ad_AdId",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Reaction_Ad_AdId",
                table: "Reaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Reaction_User_UserId",
                table: "Reaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Ad_AdId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_ReviewedId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_ReviewerId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reaction",
                table: "Reaction");

            migrationBuilder.DropIndex(
                name: "IX_Reaction_AdId",
                table: "Reaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdTag",
                table: "AdTag");

            migrationBuilder.DropIndex(
                name: "IX_AdTag_TagId",
                table: "AdTag");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reaction",
                table: "Reaction",
                columns: new[] { "AdId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdTag",
                table: "AdTag",
                columns: new[] { "TagId", "AdId" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("8056ebb5-9fd6-433c-b28d-5533e14b6a3f"), "Animals" },
                    { new Guid("f8de57a3-befa-48ee-ad1f-51b719261801"), "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "HasPremium", "LastName", "Level", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("b45ccbe5-e3ae-4d08-bf76-330419c25959"), false, "jozko@gmailol.com", "Jozko", false, "Mrkvicka", 0, "0000000", "TestUser" },
                    { new Guid("ec64bd2c-79ca-4624-b077-599aa418ecac"), false, "ferko@gmailol.com", "Ferko", false, "Priezviskovy", 0, "2020040444", "Feri" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("69c041b0-a5b7-4842-ac77-be0e245d1cd1"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("b45ccbe5-e3ae-4d08-bf76-330419c25959") });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("d120bc1d-fe97-4161-bcc2-4539f0c92f5a"), new Guid("69c041b0-a5b7-4842-ac77-be0e245d1cd1"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Id", "Message", "Rejected", "Reviewed" },
                values: new object[] { new Guid("69c041b0-a5b7-4842-ac77-be0e245d1cd1"), new Guid("ec64bd2c-79ca-4624-b077-599aa418ecac"), true, new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku", false, false });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "AdId", "Descritption", "ReviewedId", "ReviewerId", "Score" },
                values: new object[] { new Guid("e42f5477-9bea-4936-bfd8-3a3cc4d2361d"), new Guid("69c041b0-a5b7-4842-ac77-be0e245d1cd1"), "Krasna macka, 10/10 spokojnost", new Guid("b45ccbe5-e3ae-4d08-bf76-330419c25959"), new Guid("ec64bd2c-79ca-4624-b077-599aa418ecac"), 5 });

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_User_UserId",
                table: "Ad",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdTag_Ad_AdId",
                table: "AdTag",
                column: "AdId",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Ad_AdId",
                table: "Image",
                column: "AdId",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reaction_Ad_AdId",
                table: "Reaction",
                column: "AdId",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reaction_User_UserId",
                table: "Reaction",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Ad_AdId",
                table: "Review",
                column: "AdId",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_ReviewedId",
                table: "Review",
                column: "ReviewedId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_ReviewerId",
                table: "Review",
                column: "ReviewerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
