using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdTag_Ad_AdsId",
                table: "AdTag");

            migrationBuilder.DropForeignKey(
                name: "FK_AdTag_Tag_TagsId",
                table: "AdTag");

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

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "AdTag",
                newName: "AdId");

            migrationBuilder.RenameColumn(
                name: "AdsId",
                table: "AdTag",
                newName: "TagId");

            migrationBuilder.RenameIndex(
                name: "IX_AdTag_TagsId",
                table: "AdTag",
                newName: "IX_AdTag_AdId");

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("7e2ef48b-053e-4a6e-80a3-17ea6c47feef"), "Sell" },
                    { new Guid("98644e76-1757-48b3-839d-7fa3d94238bf"), "Animals" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Banned", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "Roles", "UserName" },
                values: new object[,]
                {
                    { new Guid("25fc850f-5dca-4608-bb79-cd81242bfdff"), false, "ferko@gmailol.com", "Ferko", "Priezviskovy", "supertajneheslo", "2020040444", "User", "Feri" },
                    { new Guid("7fc653e2-6b87-4a7d-b34d-e0d0af854528"), false, "jozko@gmailol.com", "Jozko", "Mrkvicka", "tajneheslo", "0000000", "User", "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("58f68a02-c9b6-42c8-b9af-be5193a53644"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("7fc653e2-6b87-4a7d-b34d-e0d0af854528") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Created", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("7fc653e2-6b87-4a7d-b34d-e0d0af854528"), new Guid("25fc850f-5dca-4608-bb79-cd81242bfdff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krasna macka, 10/10 spokojnost", new Guid("95466cc1-ffbf-4045-862d-ee5e5443b7ae"), 5 });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("99dcaaa9-4756-423e-91a2-a354aad336ec"), new Guid("58f68a02-c9b6-42c8-b9af-be5193a53644"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Created", "Id", "Message" },
                values: new object[] { new Guid("58f68a02-c9b6-42c8-b9af-be5193a53644"), new Guid("25fc850f-5dca-4608-bb79-cd81242bfdff"), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdTag_Ad_AdId",
                table: "AdTag",
                column: "AdId",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdTag_Tag_TagId",
                table: "AdTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdTag_Ad_AdId",
                table: "AdTag");

            migrationBuilder.DropForeignKey(
                name: "FK_AdTag_Tag_TagId",
                table: "AdTag");

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("99dcaaa9-4756-423e-91a2-a354aad336ec"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("58f68a02-c9b6-42c8-b9af-be5193a53644"), new Guid("25fc850f-5dca-4608-bb79-cd81242bfdff") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("7fc653e2-6b87-4a7d-b34d-e0d0af854528"), new Guid("25fc850f-5dca-4608-bb79-cd81242bfdff") });

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("7e2ef48b-053e-4a6e-80a3-17ea6c47feef"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("98644e76-1757-48b3-839d-7fa3d94238bf"));

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("58f68a02-c9b6-42c8-b9af-be5193a53644"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("25fc850f-5dca-4608-bb79-cd81242bfdff"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7fc653e2-6b87-4a7d-b34d-e0d0af854528"));

            migrationBuilder.RenameColumn(
                name: "AdId",
                table: "AdTag",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "AdTag",
                newName: "AdsId");

            migrationBuilder.RenameIndex(
                name: "IX_AdTag_AdId",
                table: "AdTag",
                newName: "IX_AdTag_TagsId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AdTag_Ad_AdsId",
                table: "AdTag",
                column: "AdsId",
                principalTable: "Ad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdTag_Tag_TagsId",
                table: "AdTag",
                column: "TagsId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
