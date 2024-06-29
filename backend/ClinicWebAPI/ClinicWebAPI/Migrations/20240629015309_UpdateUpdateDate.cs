using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUpdateDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "medicine",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 8, 53, 6, 910, DateTimeKind.Local).AddTicks(2971),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "medicine",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 8, 53, 6, 910, DateTimeKind.Local).AddTicks(2223),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 28, 12, 33, 28, 3, DateTimeKind.Local).AddTicks(8368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "medical_record",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 29, 8, 53, 6, 910, DateTimeKind.Local).AddTicks(4854),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 28, 12, 33, 28, 4, DateTimeKind.Local).AddTicks(1597));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "medicine",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 29, 8, 53, 6, 910, DateTimeKind.Local).AddTicks(2971));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "medicine",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 28, 12, 33, 28, 3, DateTimeKind.Local).AddTicks(8368),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 29, 8, 53, 6, 910, DateTimeKind.Local).AddTicks(2223));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "medical_record",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 28, 12, 33, 28, 4, DateTimeKind.Local).AddTicks(1597),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2024, 6, 29, 8, 53, 6, 910, DateTimeKind.Local).AddTicks(4854));
        }
    }
}
