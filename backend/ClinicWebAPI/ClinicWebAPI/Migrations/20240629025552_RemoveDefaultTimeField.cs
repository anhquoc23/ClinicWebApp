using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDefaultTimeField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "medicine",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 29, 2, 53, 0, 162, DateTimeKind.Utc).AddTicks(6870));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "medicine",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 29, 9, 53, 0, 162, DateTimeKind.Local).AddTicks(6195));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "medical_record",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 29, 9, 53, 0, 162, DateTimeKind.Local).AddTicks(8397));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "medicine",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 2, 53, 0, 162, DateTimeKind.Utc).AddTicks(6870),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "medicine",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 9, 53, 0, 162, DateTimeKind.Local).AddTicks(6195),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "medical_record",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 9, 53, 0, 162, DateTimeKind.Local).AddTicks(8397),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
