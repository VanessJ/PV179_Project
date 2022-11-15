using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bazaar.DAL.Migrations
{
    /// <inheritdoc />
    public partial class GuidAsId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdTag",
                keyColumns: new[] { "AdId", "TagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AdTag",
                keyColumns: new[] { "AdId", "TagId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Tag",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReviewedId",
                table: "Review",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReviewerId",
                table: "Review",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Review",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Reaction",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "AdId",
                table: "Reaction",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Reaction",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AdId",
                table: "Image",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Image",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "TagId",
                table: "AdTag",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "AdId",
                table: "AdTag",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Ad",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Ad",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { new Guid("3c86f388-50a3-4ae8-9c5d-93b07e1b003a"), "Sell" },
                    { new Guid("49308eff-3c59-483a-95e5-105c454dd97f"), "Animals" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Level", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("200c6e54-315a-411c-82b0-e07eb1c9e882"), "jozko@gmailol.com", "Jozko", "Mrkvicka", 0, "tajneheslo", "0000000", "TestUser" },
                    { new Guid("fd810cdf-49bc-4a3e-8d0e-145f2e6379ff"), "ferko@gmailol.com", "Ferko", "Priezviskovy", 0, "supertajneheslo", "2020040444", "Feri" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { new Guid("72f4b73e-eee4-4ee3-a4f0-39b86fb5b2f1"), "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", new Guid("200c6e54-315a-411c-82b0-e07eb1c9e882") });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Descritption", "Id", "Score" },
                values: new object[] { new Guid("200c6e54-315a-411c-82b0-e07eb1c9e882"), new Guid("fd810cdf-49bc-4a3e-8d0e-145f2e6379ff"), "Krasna macka, 10/10 spokojnost", new Guid("a17c8189-f949-40be-87b7-15e4df1c4eeb"), 5 });

            migrationBuilder.InsertData(
                table: "AdTag",
                columns: new[] { "AdId", "TagId" },
                values: new object[,]
                {
                    { new Guid("72f4b73e-eee4-4ee3-a4f0-39b86fb5b2f1"), new Guid("3c86f388-50a3-4ae8-9c5d-93b07e1b003a") },
                    { new Guid("72f4b73e-eee4-4ee3-a4f0-39b86fb5b2f1"), new Guid("49308eff-3c59-483a-95e5-105c454dd97f") }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { new Guid("b14f093f-0711-4dd6-a0f8-4f8b0772d5a2"), new Guid("72f4b73e-eee4-4ee3-a4f0-39b86fb5b2f1"), "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Id", "Message" },
                values: new object[] { new Guid("72f4b73e-eee4-4ee3-a4f0-39b86fb5b2f1"), new Guid("fd810cdf-49bc-4a3e-8d0e-145f2e6379ff"), true, new Guid("00000000-0000-0000-0000-000000000000"), "Mam zaujem o vasu prekrasnu macku" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdTag",
                keyColumns: new[] { "AdId", "TagId" },
                keyValues: new object[] { new Guid("72f4b73e-eee4-4ee3-a4f0-39b86fb5b2f1"), new Guid("3c86f388-50a3-4ae8-9c5d-93b07e1b003a") });

            migrationBuilder.DeleteData(
                table: "AdTag",
                keyColumns: new[] { "AdId", "TagId" },
                keyValues: new object[] { new Guid("72f4b73e-eee4-4ee3-a4f0-39b86fb5b2f1"), new Guid("49308eff-3c59-483a-95e5-105c454dd97f") });

            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("b14f093f-0711-4dd6-a0f8-4f8b0772d5a2"));

            migrationBuilder.DeleteData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { new Guid("72f4b73e-eee4-4ee3-a4f0-39b86fb5b2f1"), new Guid("fd810cdf-49bc-4a3e-8d0e-145f2e6379ff") });

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumns: new[] { "ReviewedId", "ReviewerId" },
                keyValues: new object[] { new Guid("200c6e54-315a-411c-82b0-e07eb1c9e882"), new Guid("fd810cdf-49bc-4a3e-8d0e-145f2e6379ff") });

            migrationBuilder.DeleteData(
                table: "Ad",
                keyColumn: "Id",
                keyValue: new Guid("72f4b73e-eee4-4ee3-a4f0-39b86fb5b2f1"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("3c86f388-50a3-4ae8-9c5d-93b07e1b003a"));

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: new Guid("49308eff-3c59-483a-95e5-105c454dd97f"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fd810cdf-49bc-4a3e-8d0e-145f2e6379ff"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("200c6e54-315a-411c-82b0-e07eb1c9e882"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reaction");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tag",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewedId",
                table: "Review",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewerId",
                table: "Review",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Reaction",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "AdId",
                table: "Reaction",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "AdId",
                table: "Image",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Image",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "AdTag",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "AdId",
                table: "AdTag",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Ad",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Ad",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { 1, "Animals" },
                    { 2, "Sell" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Level", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { 1, "jozko@gmailol.com", "Jozko", "Mrkvicka", 0, "tajneheslo", "0000000", "TestUser" },
                    { 2, "ferko@gmailol.com", "Ferko", "Priezviskovy", 0, "supertajneheslo", "2020040444", "Feri" }
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "Id", "Description", "IsOffer", "IsPremium", "IsValid", "Price", "Title", "UserId" },
                values: new object[] { 1, "Je velmi zlata, zbavte ma jej, prosim", true, false, true, 50, "Predam macku", 1 });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewedId", "ReviewerId", "Descritption", "Score" },
                values: new object[] { 1, 2, "Krasna macka, 10/10 spokojnost", 5 });

            migrationBuilder.InsertData(
                table: "AdTag",
                columns: new[] { "AdId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AdId", "Title", "Url" },
                values: new object[] { 1, 1, "Milovana macka", "\\obrazokmacky.jpg" });

            migrationBuilder.InsertData(
                table: "Reaction",
                columns: new[] { "AdId", "UserId", "Accepted", "Message" },
                values: new object[] { 1, 2, true, "Mam zaujem o vasu prekrasnu macku" });
        }
    }
}
