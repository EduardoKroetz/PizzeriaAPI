using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaApi.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPizzas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 56, DateTimeKind.Utc).AddTicks(2911),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 285, DateTimeKind.Utc).AddTicks(5234));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 56, DateTimeKind.Utc).AddTicks(2454),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 285, DateTimeKind.Utc).AddTicks(4772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 57, DateTimeKind.Utc).AddTicks(2666),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(5581));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 57, DateTimeKind.Utc).AddTicks(2270),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(5137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 62, DateTimeKind.Utc).AddTicks(3755),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 290, DateTimeKind.Utc).AddTicks(8855));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 62, DateTimeKind.Utc).AddTicks(3029),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 290, DateTimeKind.Utc).AddTicks(8357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 62, DateTimeKind.Utc).AddTicks(6808),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 291, DateTimeKind.Utc).AddTicks(651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 62, DateTimeKind.Utc).AddTicks(6053),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 291, DateTimeKind.Utc).AddTicks(192));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 57, DateTimeKind.Utc).AddTicks(4167),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(7052));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 57, DateTimeKind.Utc).AddTicks(3796),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(6684));

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    Qtd = table.Column<int>(type: "INT", nullable: false, defaultValue: 1),
                    OrderId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    PizzaId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Pizzas",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_OrderItems",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PizzaId",
                table: "OrderItems",
                column: "PizzaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 285, DateTimeKind.Utc).AddTicks(5234),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 56, DateTimeKind.Utc).AddTicks(2911));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 285, DateTimeKind.Utc).AddTicks(4772),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 56, DateTimeKind.Utc).AddTicks(2454));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(5581),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 57, DateTimeKind.Utc).AddTicks(2666));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Pizzas",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(5137),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 57, DateTimeKind.Utc).AddTicks(2270));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 290, DateTimeKind.Utc).AddTicks(8855),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 62, DateTimeKind.Utc).AddTicks(3755));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Payaments",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 290, DateTimeKind.Utc).AddTicks(8357),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 62, DateTimeKind.Utc).AddTicks(3029));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 291, DateTimeKind.Utc).AddTicks(651),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 62, DateTimeKind.Utc).AddTicks(6808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 291, DateTimeKind.Utc).AddTicks(192),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 62, DateTimeKind.Utc).AddTicks(6053));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(7052),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 57, DateTimeKind.Utc).AddTicks(4167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Menus",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 30, 22, 51, 8, 286, DateTimeKind.Utc).AddTicks(6684),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2024, 3, 31, 1, 31, 16, 57, DateTimeKind.Utc).AddTicks(3796));

            migrationBuilder.CreateTable(
                name: "OrderPizzas",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    PizzaId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizzas", x => new { x.OrderId, x.PizzaId });
                    table.ForeignKey(
                        name: "FK_OrderPizzas_Orders",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPizzas_Pizzas",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizzas_PizzaId",
                table: "OrderPizzas",
                column: "PizzaId");
        }
    }
}
