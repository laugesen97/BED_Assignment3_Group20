using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment3_Group20.Data.Migrations
{
    public partial class checkedinBoolAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "checkedInBool",
                table: "Reservation",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "ID",
                keyValue: 1,
                column: "isCheckedIn",
                value: new DateTime(2022, 4, 20, 15, 49, 21, 187, DateTimeKind.Local).AddTicks(4118));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "checkedInBool",
                table: "Reservation");

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "ID",
                keyValue: 1,
                column: "isCheckedIn",
                value: new DateTime(2022, 4, 7, 11, 31, 23, 101, DateTimeKind.Local).AddTicks(6792));
        }
    }
}
