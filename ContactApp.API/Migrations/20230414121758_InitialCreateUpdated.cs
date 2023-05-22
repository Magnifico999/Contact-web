using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactApp.API.Migrations
{
    public partial class InitialCreateUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Address",
                value: "Lagos");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1002,
                column: "Address",
                value: "Kano");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1003,
                column: "Address",
                value: "Jamaica");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1004,
                column: "Address",
                value: "USA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1001,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1002,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1003,
                column: "Address",
                value: null);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1004,
                column: "Address",
                value: null);
        }
    }
}
