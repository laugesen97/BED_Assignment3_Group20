using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment3_Group20.Data.Migrations
{
    public partial class seededDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "ID", "Adults", "Children", "RoomNumber", "isCheckedIn" },
                values: new object[] { 1, 2, 2, 1, new DateTime(2022, 4, 7, 10, 51, 54, 105, DateTimeKind.Local).AddTicks(4405) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservation",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
