using Microsoft.EntityFrameworkCore.Migrations;

namespace IdentityExample.Migrations
{
    public partial class IdentityTableFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27d973af-73df-4455-88b1-2a623d9eb1a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b781bd1f-2dcf-4e33-9fda-077549280562");

            migrationBuilder.DropColumn(
                name: "FistName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "21719d6d-42b1-4d15-8de7-06b13e108031", "0dd372d5-1c7c-432b-bb79-cdd812ad09d2", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e10f08bc-0319-4d42-8126-e2e0594a5c14", "bc1df0d0-ed49-4f28-94dd-32cf2497e26b", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21719d6d-42b1-4d15-8de7-06b13e108031");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e10f08bc-0319-4d42-8126-e2e0594a5c14");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FistName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b781bd1f-2dcf-4e33-9fda-077549280562", "886bfdf1-da70-4df2-a20e-0e9c78996fe0", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27d973af-73df-4455-88b1-2a623d9eb1a5", "38ee3940-f548-4b28-9c37-d3d0b0c0f06f", "Administrator", "ADMINISTRATOR" });
        }
    }
}
