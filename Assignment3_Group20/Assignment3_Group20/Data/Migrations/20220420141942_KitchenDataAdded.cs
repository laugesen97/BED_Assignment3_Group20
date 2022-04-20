using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment3_Group20.Data.Migrations
{
    public partial class KitchenDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "ID",
                keyValue: 1,
                column: "isCheckedIn",
                value: new DateTime(2022, 4, 20, 16, 19, 41, 818, DateTimeKind.Local).AddTicks(4012));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "ID",
                keyValue: 1,
                column: "isCheckedIn",
                value: new DateTime(2022, 4, 20, 15, 49, 21, 187, DateTimeKind.Local).AddTicks(4118));
        }
    }
}
