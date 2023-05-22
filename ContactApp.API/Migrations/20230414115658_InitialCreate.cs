using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactApp.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "Occupation", "PhotoPath" },
                values: new object[,]
                {
                    { 1001, null, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@example.com", "John", 0, "Doe", "Engineer", "Images/john.jpg" },
                    { 1002, null, new DateTime(1985, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarahj@example.com", "Sarah", 1, "Johnson", "Entrepreneur", "Images/sarah.jpg" },
                    { 1003, null, new DateTime(1988, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "michaels@example.com", "Michael", 0, "Smith", "Doctor", "Images/michael.jpeg" },
                    { 1004, null, new DateTime(1989, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "mauriceg@example.com", "Maurice", 0, "Gray", "Banker", "Images/maurice.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
