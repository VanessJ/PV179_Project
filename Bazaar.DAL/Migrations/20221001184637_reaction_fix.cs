using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazaar.DAL.Migrations
{
    public partial class reaction_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "Reaction",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Reaction",
                keyColumns: new[] { "AdId", "UserId" },
                keyValues: new object[] { 1, 2 },
                column: "Accepted",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "Reaction");
        }
    }
}
