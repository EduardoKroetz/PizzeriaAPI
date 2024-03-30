using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMenuIdFromPizzas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "Pizzas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 360, DateTimeKind.Utc).AddTicks(3551),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 937, DateTimeKind.Utc).AddTicks(6758));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 360, DateTimeKind.Utc).AddTicks(3112),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 937, DateTimeKind.Utc).AddTicks(6303));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(2596),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 938, DateTimeKind.Utc).AddTicks(6014));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(2177),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 938, DateTimeKind.Utc).AddTicks(5537));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(4514),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 942, DateTimeKind.Utc).AddTicks(7989));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(4021),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 942, DateTimeKind.Utc).AddTicks(7507));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(6441),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 942, DateTimeKind.Utc).AddTicks(9729));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(5980),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 942, DateTimeKind.Utc).AddTicks(9276));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(3952),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 938, DateTimeKind.Utc).AddTicks(7504));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(3592),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 938, DateTimeKind.Utc).AddTicks(7139));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 937, DateTimeKind.Utc).AddTicks(6758),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 360, DateTimeKind.Utc).AddTicks(3551));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 937, DateTimeKind.Utc).AddTicks(6303),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 360, DateTimeKind.Utc).AddTicks(3112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 938, DateTimeKind.Utc).AddTicks(6014),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(2596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 938, DateTimeKind.Utc).AddTicks(5537),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(2177));

            migrationBuilder.AddColumn<Guid>(
                name: "MenuId",
                table: "Pizzas",
                type: "UNIQUEIDENTIFIER",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 942, DateTimeKind.Utc).AddTicks(7989),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(4514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 942, DateTimeKind.Utc).AddTicks(7507),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(4021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 942, DateTimeKind.Utc).AddTicks(9729),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(6441));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 942, DateTimeKind.Utc).AddTicks(9276),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 365, DateTimeKind.Utc).AddTicks(5980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 938, DateTimeKind.Utc).AddTicks(7504),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(3952));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 29, 23, 48, 59, 938, DateTimeKind.Utc).AddTicks(7139),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 29, 23, 56, 29, 361, DateTimeKind.Utc).AddTicks(3592));
        }
    }
}
