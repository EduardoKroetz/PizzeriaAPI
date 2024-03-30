using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmailColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Number",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 216, DateTimeKind.Utc).AddTicks(1335),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 917, DateTimeKind.Utc).AddTicks(3773));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 216, DateTimeKind.Utc).AddTicks(732),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 917, DateTimeKind.Utc).AddTicks(3297));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(5508),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(4933));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(4869),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(4514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(6920),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 923, DateTimeKind.Utc).AddTicks(626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(6335),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 922, DateTimeKind.Utc).AddTicks(9723));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(8953),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 923, DateTimeKind.Utc).AddTicks(2508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(8492),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 923, DateTimeKind.Utc).AddTicks(2052));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(7532),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(6482));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(6979),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(6116));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Number");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "Users",
                newName: "IX_Users_Number");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 917, DateTimeKind.Utc).AddTicks(3773),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 216, DateTimeKind.Utc).AddTicks(1335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 917, DateTimeKind.Utc).AddTicks(3297),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 216, DateTimeKind.Utc).AddTicks(732));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(4933),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(5508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(4514),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(4869));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 923, DateTimeKind.Utc).AddTicks(626),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(6920));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 922, DateTimeKind.Utc).AddTicks(9723),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 923, DateTimeKind.Utc).AddTicks(2508),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(8953));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 923, DateTimeKind.Utc).AddTicks(2052),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(8492));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(6482),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(7532));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(6116),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(6979));
        }
    }
}
