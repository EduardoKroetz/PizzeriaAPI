using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCartRelationToCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartCartItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 285, DateTimeKind.Utc).AddTicks(5234),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 216, DateTimeKind.Utc).AddTicks(1335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 285, DateTimeKind.Utc).AddTicks(4772),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 216, DateTimeKind.Utc).AddTicks(732));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(5581),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(5508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(5137),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(4869));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 290, DateTimeKind.Utc).AddTicks(8855),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(6920));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 290, DateTimeKind.Utc).AddTicks(8357),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(6335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 291, DateTimeKind.Utc).AddTicks(651),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(8953));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 291, DateTimeKind.Utc).AddTicks(192),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(8492));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(7052),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(7532));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(6684),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(6979));

            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "CartItems",
                type: "UNIQUEIDENTIFIER",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_CartItems",
                table: "CartItems",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_CartItems",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "CartItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 216, DateTimeKind.Utc).AddTicks(1335),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 285, DateTimeKind.Utc).AddTicks(5234));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 216, DateTimeKind.Utc).AddTicks(732),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 285, DateTimeKind.Utc).AddTicks(4772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(5508),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(5581));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(4869),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(5137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(6920),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 290, DateTimeKind.Utc).AddTicks(8855));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(6335),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 290, DateTimeKind.Utc).AddTicks(8357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(8953),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 291, DateTimeKind.Utc).AddTicks(651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 223, DateTimeKind.Utc).AddTicks(8492),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 291, DateTimeKind.Utc).AddTicks(192));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(7532),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(7052));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 17, 33, 11, 217, DateTimeKind.Utc).AddTicks(6979),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(6684));

            migrationBuilder.CreateTable(
                name: "CartCartItems",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    CartItemId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartCartItems", x => new { x.CartId, x.CartItemId });
                    table.ForeignKey(
                        name: "FK_CartCartItems_Cart",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartCartItems_CartItem",
                        column: x => x.CartItemId,
                        principalTable: "CartItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartCartItems_CartItemId",
                table: "CartCartItems",
                column: "CartItemId");
        }
    }
}
