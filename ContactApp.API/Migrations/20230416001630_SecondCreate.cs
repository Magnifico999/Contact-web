using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactApp.API.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phonenumber",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Phonenumber",
                value: "+2349050160648");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1002,
                column: "Phonenumber",
                value: "+2347069357893");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1003,
                column: "Phonenumber",
                value: "+2348165473980");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1004,
                column: "Phonenumber",
                value: "+2347684567806");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phonenumber",
                table: "Contacts");
        }
    }
}
