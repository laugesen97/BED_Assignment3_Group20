using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment3_Group20.Data.Migrations
{
    public partial class NewReservationDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FutureReservation",
                columns: table => new
                {
                    FutureReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adults = table.Column<int>(type: "int", nullable: false),
                    Children = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureReservation", x => x.FutureReservationId);
                });

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "ID",
                keyValue: 1,
                column: "isCheckedIn",
                value: new DateTime(2022, 4, 7, 11, 31, 23, 101, DateTimeKind.Local).AddTicks(6792));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FutureReservation");

            migrationBuilder.UpdateData(
                table: "Reservation",
                keyColumn: "ID",
                keyValue: 1,
                column: "isCheckedIn",
                value: new DateTime(2022, 4, 7, 10, 51, 54, 105, DateTimeKind.Local).AddTicks(4405));
        }
    }
}
