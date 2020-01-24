using Microsoft.EntityFrameworkCore.Migrations;

namespace Banksy.WebAPI.Migrations
{
    public partial class FixTypoInMutationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MutaionType",
                table: "Mutations");

            migrationBuilder.AddColumn<string>(
                name: "MutationType",
                table: "Mutations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MutationType",
                table: "Mutations");

            migrationBuilder.AddColumn<string>(
                name: "MutaionType",
                table: "Mutations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
