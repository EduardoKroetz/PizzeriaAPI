using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Street = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    Number = table.Column<int>(type: "INT", nullable: false),
                    ComplementOrReference = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    ProductQtd = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2024, 3, 29, 21, 44, 16, 189, DateTimeKind.Utc).AddTicks(1302)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2024, 3, 29, 21, 44, 16, 189, DateTimeKind.Utc).AddTicks(1662))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Fullname = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Number = table.Column<string>(type: "NVARCHAR(160)", maxLength: 160, nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    Image = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    IsAdmin = table.Column<bool>(type: "BIT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2024, 3, 29, 21, 44, 16, 188, DateTimeKind.Utc).AddTicks(380)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2024, 3, 29, 21, 44, 16, 188, DateTimeKind.Utc).AddTicks(840)),
                    CartId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Flavors = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    IsFrozen = table.Column<bool>(type: "BIT", nullable: false),
                    Size = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    InStock = table.Column<int>(type: "INT", nullable: false),
                    Rating = table.Column<int>(type: "INT", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2024, 3, 29, 21, 44, 16, 188, DateTimeKind.Utc).AddTicks(9805)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2024, 3, 29, 21, 44, 16, 189, DateTimeKind.Utc).AddTicks(246)),
                    MenuId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Pizzas",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2024, 3, 29, 21, 44, 16, 189, DateTimeKind.Utc).AddTicks(8114)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2024, 3, 29, 21, 44, 16, 189, DateTimeKind.Utc).AddTicks(8568)),
                    AddressId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Orders",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payaments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2024, 3, 29, 21, 44, 16, 189, DateTimeKind.Utc).AddTicks(6239)),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValue: new DateTime(2024, 3, 29, 21, 44, 16, 189, DateTimeKind.Utc).AddTicks(6677)),
                    UserId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Payaments",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(8,2)", nullable: false),
                    Qtd = table.Column<int>(type: "INT", nullable: false),
                    PizzaId = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Pizzas",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_PizzaId",
                table: "CartItems",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizzas_PizzaId",
                table: "OrderPizzas",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payaments_UserId",
                table: "Payaments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_MenuId",
                table: "Pizzas",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CartId",
                table: "Users",
                column: "CartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Number",
                table: "Users",
                column: "Number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartCartItems");

            migrationBuilder.DropTable(
                name: "OrderPizzas");

            migrationBuilder.DropTable(
                name: "Payaments");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
