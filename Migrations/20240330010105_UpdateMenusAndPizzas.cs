using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMenusAndPizzas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 917, DateTimeKind.Utc).AddTicks(3773),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 360, DateTimeKind.Utc).AddTicks(3551));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 917, DateTimeKind.Utc).AddTicks(3297),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 360, DateTimeKind.Utc).AddTicks(3112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(4933),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(2596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(4514),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(2177));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 923, DateTimeKind.Utc).AddTicks(626),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(4514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 922, DateTimeKind.Utc).AddTicks(9723),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(4021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 923, DateTimeKind.Utc).AddTicks(2508),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(6441));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 923, DateTimeKind.Utc).AddTicks(2052),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(5980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(6482),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(3952));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(6116),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(3592));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Menus",
                type: "NVARCHAR(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_Name",
                table: "Pizzas",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pizzas_Name",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Menus");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 360, DateTimeKind.Utc).AddTicks(3551),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 917, DateTimeKind.Utc).AddTicks(3773));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 360, DateTimeKind.Utc).AddTicks(3112),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 917, DateTimeKind.Utc).AddTicks(3297));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(2596),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(4933));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(2177),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(4514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(4514),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 923, DateTimeKind.Utc).AddTicks(626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(4021),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 922, DateTimeKind.Utc).AddTicks(9723));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(6441),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 923, DateTimeKind.Utc).AddTicks(2508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(5980),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 923, DateTimeKind.Utc).AddTicks(2052));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(3952),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(6482));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(3592),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 1, 1, 4, 918, DateTimeKind.Utc).AddTicks(6116));
        }
    }
}
