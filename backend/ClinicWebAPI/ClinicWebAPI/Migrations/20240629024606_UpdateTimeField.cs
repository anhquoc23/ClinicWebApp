using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTimeField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "medicine",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 9, 46, 6, 38, DateTimeKind.Local).AddTicks(9947),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 29, 8, 53, 6, 910, DateTimeKind.Local).AddTicks(2971));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "medicine",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 9, 46, 6, 38, DateTimeKind.Local).AddTicks(8991),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 29, 8, 53, 6, 910, DateTimeKind.Local).AddTicks(2223));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "medical_record",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 9, 46, 6, 39, DateTimeKind.Local).AddTicks(2266),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 29, 8, 53, 6, 910, DateTimeKind.Local).AddTicks(4854));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "medicine",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 8, 53, 6, 910, DateTimeKind.Local).AddTicks(2971),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 29, 9, 46, 6, 38, DateTimeKind.Local).AddTicks(9947));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "medicine",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 8, 53, 6, 910, DateTimeKind.Local).AddTicks(2223),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 29, 9, 46, 6, 38, DateTimeKind.Local).AddTicks(8991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "medical_record",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 8, 53, 6, 910, DateTimeKind.Local).AddTicks(4854),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 29, 9, 46, 6, 39, DateTimeKind.Local).AddTicks(2266));
        }
    }
}
