using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaApi.Migrations
{
    /// <inheritdoc />
    public partial class PayamentRelationAndFinishField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Payaments");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 984, DateTimeKind.Utc).AddTicks(462),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 208, DateTimeKind.Utc).AddTicks(7257));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 984, DateTimeKind.Utc).AddTicks(30),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 208, DateTimeKind.Utc).AddTicks(6534));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 985, DateTimeKind.Utc).AddTicks(341),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 211, DateTimeKind.Utc).AddTicks(355));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 984, DateTimeKind.Utc).AddTicks(9941),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 210, DateTimeKind.Utc).AddTicks(9851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 990, DateTimeKind.Utc).AddTicks(4077),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 220, DateTimeKind.Utc).AddTicks(4592));

            migrationBuilder.AddColumn<bool>(
                name: "Finish",
                table: "Payaments",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Payaments",
                type: "UNIQUEIDENTIFIER",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 990, DateTimeKind.Utc).AddTicks(8549),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 220, DateTimeKind.Utc).AddTicks(8270));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 985, DateTimeKind.Utc).AddTicks(1863),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 211, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 985, DateTimeKind.Utc).AddTicks(1487),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 211, DateTimeKind.Utc).AddTicks(3240));

            migrationBuilder.CreateIndex(
                name: "IX_Payaments_OrderId",
                table: "Payaments",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payaments_Orders",
                table: "Payaments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payaments_Orders",
                table: "Payaments");

            migrationBuilder.DropIndex(
                name: "IX_Payaments_OrderId",
                table: "Payaments");

            migrationBuilder.DropColumn(
                name: "Finish",
                table: "Payaments");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Payaments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 208, DateTimeKind.Utc).AddTicks(7257),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 984, DateTimeKind.Utc).AddTicks(462));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 208, DateTimeKind.Utc).AddTicks(6534),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 984, DateTimeKind.Utc).AddTicks(30));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 211, DateTimeKind.Utc).AddTicks(355),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 985, DateTimeKind.Utc).AddTicks(341));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 210, DateTimeKind.Utc).AddTicks(9851),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 984, DateTimeKind.Utc).AddTicks(9941));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 220, DateTimeKind.Utc).AddTicks(4592),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 990, DateTimeKind.Utc).AddTicks(4077));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 220, DateTimeKind.Utc).AddTicks(5198));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 220, DateTimeKind.Utc).AddTicks(8270),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 990, DateTimeKind.Utc).AddTicks(8549));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 220, DateTimeKind.Utc).AddTicks(8709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 211, DateTimeKind.Utc).AddTicks(3740),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 985, DateTimeKind.Utc).AddTicks(1863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 18, 16, 18, 211, DateTimeKind.Utc).AddTicks(3240),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 20, 21, 57, 985, DateTimeKind.Utc).AddTicks(1487));
        }
    }
}
